using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using SemaforoWeb.Email;
using SemaforoWeb.SettingsModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly db_9bc4da_semaforoContext _context;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;
        private readonly IEmailSender _emailSender;
        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            db_9bc4da_semaforoContext context,
            IMapper mapper,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _authService = new AuthService(context, mapper, null);
            _emailSender = emailSender;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = false };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var emailBody = $"Por favor confirme su correo con este link <a href=\"#URL#\"> click aqui </a> Link 2: \"#URL2#\"";
                    string url = Request.Scheme + "://" + Request.Host + "/ConfirmEmail";
                    var callbackUrl = new Uri(QueryHelpers.AddQueryString(url, new Dictionary<string, string>() { { "userId", appUser.Id }, { "code", code.Result } }));
                    //var callbackUrl2 = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Auth", values: new { userId = appUser.Id, code = code.Result });
                    var body = emailBody.Replace("#URL#", callbackUrl.ToString());
                    //body = body.Replace("#URL2#", callbackUrl2);
                    try
                    {
                        ApplicationUserBO newUser = _mapper.Map<ApplicationUserBO>(model);
                        _mapper.Map(appUser, newUser);
                        int userId = await _authService.RegisterApplicationUser(newUser);
                        await _emailSender.SendEmailAsync(appUser.Email, _configuration.GetValue<string>("CompanyName") + ": Verifica tu Cuenta", body);
                        return Ok("Verification Email Sent");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Error at send verification Email: "+ ex.Message);
                    }
                }
                else
                {
                    string messages = string.Join("\n ", result.Errors.Select(e => e.Description).ToList());
                    return BadRequest(messages);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code) {
            if (userId == null || code == null) {
                return BadRequest("Invalid Email confirmation URL");
            }
            var appUser = await _userManager.FindByIdAsync(userId);
            if (appUser == null)
            {
                return BadRequest("Invalid Email parameters");
            }
            var result = await _userManager.ConfirmEmailAsync(appUser, code);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false); 
                var user = await BuildToken(appUser);
                return Ok(user);
            }
            else {
                return  BadRequest("tu correo no ha sido confirmado, por favor intentelo mas tarde");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(userInfo.Username, userInfo.Password, isPersistent: true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var appUser = await _signInManager.UserManager.FindByNameAsync(userInfo.Username);
                        if (appUser.EmailConfirmed)
                        {
                            var user = await BuildToken(appUser);
                            return Ok(user);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Email not confirmed");
                            return BadRequest(ModelState);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid credentials.");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        readonly string _facebookAPI = "https://graph.facebook.com/v17.0/";
        private async Task<byte[]> SaveFacebookProfileImage(UserLoginSocialDTO userInfo, int employeeId) {
            string token = userInfo.Data.accessToken;
            string userID = userInfo.Data.userID;
            using (var http = new HttpClient())
            {
                var httpResponse = await http.GetAsync($"{_facebookAPI}{userID}/picture?access_token={token}&height=720&width=720");
                var httpContent = await httpResponse.Content.ReadAsByteArrayAsync();
                if (employeeId > 0)
                    await _authService.updateFacebookImage(employeeId, httpContent);
                return httpContent;
                //System.IO.File.WriteAllBytes("face.png", httpContent);
                //var imagex =  "data:image/png;base64," + Convert.ToBase64String(httpContent);
            }
        }

        [HttpPost]
        [Route("SocialLogin")]
        public async Task<IActionResult> SocialLogin([FromBody] UserLoginSocialDTO userInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = await _userManager.FindByEmailAsync(userInfo.Data.email);
                    if (appUser == null)
                    {
                        // register
                        appUser = new ApplicationUser { UserName = userInfo.Data.email, Email = userInfo.Data.email, EmailConfirmed = true };
                        var result = await _userManager.CreateAsync(appUser);
                        if (result.Succeeded)
                        {
                            ApplicationUserBO newUser = _mapper.Map<ApplicationUserBO>(userInfo);
                            _mapper.Map(appUser, newUser);
                            newUser.ProfileImage = await SaveFacebookProfileImage(userInfo, newUser.EmployeeId);
                            int userId = await _authService.RegisterApplicationUser(newUser);
                            await _signInManager.SignInAsync(appUser, isPersistent: false);
                            var user = await BuildToken(appUser);
                            user.ProfileImage = "data:image/png;base64," + Convert.ToBase64String(newUser.ProfileImage);
                            return Ok(user);
                        }
                        else
                        {
                            string messages = string.Join("\n ", result.Errors.Select(e => e.Description).ToList());
                            return BadRequest(messages);
                        }
                    }
                    else
                    {
                        // login
                        await _signInManager.SignInAsync(appUser, isPersistent: false);
                        var user = await BuildToken(appUser);
                        var imageByteArray = await SaveFacebookProfileImage(userInfo, user.EmployeeId);
                        user.ProfileImage = "data:image/png;base64," + Convert.ToBase64String(imageByteArray);


                        return Ok(user);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        private async Task<ApplicationUserDTO> BuildToken(ApplicationUser userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSettings = _configuration.GetSection("JWT").Get<JWTSettings>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.ServerSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(12);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: jwtSettings.Issuer,
               audience: jwtSettings.Audience,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            ApplicationUserDTO appUser = _mapper.Map<ApplicationUserDTO>(userInfo);
            ApplicationUserBO applicationUserBO = await _authService.getUserInfoFromEmployee(appUser.AppUserId);
            _mapper.Map(applicationUserBO, appUser);
            //appUser.Token = new JwtSecurityTokenHandler().WriteToken(token);
            //appUser.Expiration= expiration;

            return appUser;

        }

        private void SendEmail(string body, string email) {
        
        }
    }
}