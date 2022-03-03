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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly StockService _stockService;
        private readonly IMapper _mapper;

        public StockController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _stockService = new StockService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<StockBO>>> GetStocks()
        {
            try
            {
                var stocks = await _stockService.GetStockList();
                if (stocks == null)
                {
                    return null;
                }
                return Catalog<StockBO>.BuildCatalog(Catalog<StockBO>.StockColumnsConfigs, stocks, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
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
