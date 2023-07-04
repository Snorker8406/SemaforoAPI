using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                var appUser = new ApplicationUser { UserName = model.Username, Email = model.Email, EmailConfirmed = false };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var emailBody = $"Por favor confirme su correo con este link <a href=\"#URL#\"> click aqui </a>";

                    var callbackUrl = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Auth", values: new { userId = appUser.Id, code = code.Result });
                    var body = emailBody.Replace("#URL#", callbackUrl);
                    try
                    {
                        await _emailSender.SendEmailAsync(appUser.Email, _configuration.GetValue<string>("CompanyName") + ": Verifica tu Cuenta", body);
                        return Ok("Por favor verifica tu cuenta en el correo electronico que te acabamos de enviar");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Error en el envío de correo de verificación: "+ ex.Message);
                    }

                    //ApplicationUserBO newUser = _mapper.Map<ApplicationUserBO>(model);
                    //_mapper.Map(appUser, newUser);
                    //int userId = await _authService.RegisterApplicationUser(newUser);
                    //return Ok(userId);
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
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Invalid Email parameters");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            var status = result.Succeeded ? "cuenta validada correctamente" : "tu correo no ha sido confirmado, por favor intentelo mas tarde";

            return Ok();
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
                    var user = await _signInManager.UserManager.FindByNameAsync(userInfo.Username);
                    if (user.EmailConfirmed)
                    {
                        return BuildToken(userInfo);
                    }
                    else {
                        ModelState.AddModelError(string.Empty, "Email needs to be confirmed");
                        return BadRequest(ModelState);
                    }                        
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(UserLoginDTO userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Username),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["App_Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "elsemaforouniformes.com",
               audience: "elsemaforouniformes.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }

        private void SendEmail(string body, string email) {
        
        }
    }
}