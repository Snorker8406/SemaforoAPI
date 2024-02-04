using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semaforo.Web.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Semaforo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTypeController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public SalesTypeController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<SalesTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesTypeDTO>>> GetSalesTypes()
        {
            var salesTypes = await _context.SalesTypes.ToListAsync();
            List<SalesTypeDTO> salesTypeDTOs = new List<SalesTypeDTO>();

            return salesTypeDTOs;
        }

        // GET api/<SalesTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesTypeController>
        [HttpPost]
        public async Task<ActionResult<SalesType>> PostSalesType(SalesType salesType)
        {

            _context.SalesTypes.Add(salesType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesType", new { id = salesType.SaleTypeId }, salesType);
        }

        // PUT api/<SalesTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
