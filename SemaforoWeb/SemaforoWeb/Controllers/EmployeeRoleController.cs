using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using SemaforoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public EmployeeRoleController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<EmployeeRoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRoleDTO>>> GetEmployeeRoles()
        {
            var employeeRoles = await _context.EmployeeRoles.ToListAsync();
            List<EmployeeRoleDTO> employeeRoleDTOs = new List<EmployeeRoleDTO>();

            return employeeRoleDTOs;
        }

        // GET api/<EmployeeRoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeRoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeRoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
