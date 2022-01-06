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
    public class PriceController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public PriceController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<PriceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> GetPrices()
        {
            var prices = await _context.ProductPrices.ToListAsync();
            List<PriceDTO> priceDTOs = new List<PriceDTO>();

            return priceDTOs;
        }

        // GET api/<PriceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PriceController>
        [HttpPost]
        public async Task<ActionResult<ProductPrice>> PostPrice(ProductPrice price)
        {

            _context.ProductPrices.Add(price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrices", new { id = price.PriceId }, price);
        }

        // PUT api/<PriceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PriceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
