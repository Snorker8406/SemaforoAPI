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
    public class SaleController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public SaleController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<SaleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetSales()
        {
            var sales = await _context.Sales.ToListAsync();
            List<SaleDTO> saleDTOs = new List<SaleDTO>();

            return saleDTOs;
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SaleController>
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.SaleId }, sale);
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
