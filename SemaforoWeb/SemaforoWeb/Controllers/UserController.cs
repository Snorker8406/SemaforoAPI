using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using Semaforo.Logic.Services;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly AuthService _userService;
        private readonly IMapper _mapper;

        public UserController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _userService = new AuthService(context, mapper, null);
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<CatalogDTO<ApplicationUserBO>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUserList();
                if (users == null)
                {
                    return null;
                }
                return Catalog<ApplicationUserBO>.BuildCatalog(Catalog<ApplicationUserBO>.UserColumnsConfigs, users, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{

        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUsers", new { id = user.UserId }, user);
        //}

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
