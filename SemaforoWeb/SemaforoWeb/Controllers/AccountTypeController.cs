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
    public class AccountTypeController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public AccountTypeController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<AccountTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTypeDTO>>> GetAccountTypes()
        {
            var accountTypes = await _context.AccountTypes.ToListAsync();
            List<AccountTypeDTO> accounttypeDTOs = new List<AccountTypeDTO>();

            return accounttypeDTOs;
        }

        // GET api/<AccountTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
