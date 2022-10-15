using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public RoleController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            List<RoleDTO> roleDTOs = new List<RoleDTO>();

            return roleDTOs;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        //[HttpPost]
        //public async Task<ActionResult<Role>> PostRole(Role role)
        //{

        //    _context.Roles.Add(role);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRole", new { id = role.RoleId }, role);
        //}

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
