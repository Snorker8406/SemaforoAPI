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
    public class SalesDetailController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public SalesDetailController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<SalesDetailController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDetailDTO>>> GetSalesDetails()
        {
            var salesDetail = await _context.SalesDetails.ToListAsync();
            List<SalesDetailDTO> salesDetailDTOs = new List<SalesDetailDTO>();

            return salesDetailDTOs;
        }

        // GET api/<SalesDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesDetailsController>
        [HttpPost]
        public async Task<ActionResult<SalesDetail>> PostSaleDetail(SalesDetail salesDetail)
        {

            _context.SalesDetails.Add(salesDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesDetail", new { id = salesDetail.SaleId }, salesDetail);
        }


        // PUT api/<SalesDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
