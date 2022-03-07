using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaforo.Logic.Services;
using AutoMapper;
using SemaforoWeb.DTO.CatalogsDTO;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public StockController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<SalesDetailController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocks()
        {
            var stock = await _context.Stocks.ToListAsync();
            List<StockDTO> stockDTOs = new List<StockDTO>();

            return stockDTOs;
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockController>
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.StockId }, stock);
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
