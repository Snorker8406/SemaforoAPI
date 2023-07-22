using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using SemaforoWeb.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
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
                    var callbackUrl2 = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Auth", values: new { userId = appUser.Id, code = code.Result });
                    var body = emailBody.Replace("#URL#", callbackUrl.ToString());
                    body = body.Replace("#URL2#", callbackUrl2);
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
                    else {
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

        [HttpPost]
        [Route("SocialLogin")]
        public async Task<IActionResult> SocialLogin([FromBody] UserLoginSocialDTO userInfo)
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
                        int userId = await _authService.RegisterApplicationUser(newUser);
                        await _signInManager.SignInAsync(appUser, isPersistent: false);
                        var user = await BuildToken(appUser);
                        return Ok(user);
                    }
                    else
                    {
                        string messages = string.Join("\n ", result.Errors.Select(e => e.Description).ToList());
                        return BadRequest(messages);
                    }
                }
                else {
                    // login
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    var user = await BuildToken(appUser);
                    return Ok(user);
                }
            }
            else
            {
                return BadRequest(ModelState);
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["App_Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(12);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "elsemaforouniformes.com",
               audience: "elsemaforouniformes.com",
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