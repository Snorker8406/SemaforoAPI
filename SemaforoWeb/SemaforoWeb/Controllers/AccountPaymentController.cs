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
    public class AccountPaymentController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public AccountPaymentController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<AccountPaymentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountPaymentDTO>>> GetAccountPayment()
        {
            var accountPayments = await _context.AccountPayments.ToListAsync();
            List<AccountPaymentDTO> accountpaymentDTOs = new List<AccountPaymentDTO>();

            return accountpaymentDTOs;
        }

            // GET api/<AccountPaymentController>/5
            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountPaymentController>
        [HttpPost]
        public async Task<ActionResult<AccountPayment>> PostAccountPayment(AccountPayment accountPayment)
        {

            _context.AccountPayments.Add(accountPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountPayment", new { id = accountPayment.AccountPaymentId }, accountPayment);
        }

        // PUT api/<AccountPaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountPaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
