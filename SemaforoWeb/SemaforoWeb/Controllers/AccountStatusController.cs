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
    public class AccountStatusController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public AccountStatusController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<AccountStatusController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountStatusDTO>>> GetAccountStatus()
        {
            var accountStatuses = await _context.AccountStatuses.ToListAsync();
            List<AccountStatusDTO> accountstatusDTOs = new List<AccountStatusDTO>();

            return accountstatusDTOs;
        }

        // GET api/<AccountStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
