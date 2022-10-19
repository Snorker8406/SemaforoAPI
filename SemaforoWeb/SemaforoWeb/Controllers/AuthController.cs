using AutoMapper;
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
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            db_9bc4da_semaforoContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
            _context = context;
            _mapper = mapper;
            _authService = new AuthService(context, mapper, null);
        }

        //[Route("Create")]
        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] UserLoginDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return BuildToken(model);
        //        }
        //        else
        //        {
        //            return BadRequest("Username or password invalid");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    ApplicationUserBO newUser = _mapper.Map<ApplicationUserBO>(model);
                    _mapper.Map(appUser, newUser);
                    int userId = await _authService.RegisterApplicationUser(newUser);
                    return Ok(userId);
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Username, userInfo.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(userInfo);
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
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
    }
}