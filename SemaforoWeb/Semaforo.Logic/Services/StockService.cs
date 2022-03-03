using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Semaforo.Logic.Services
{
    public class StockService : BaseService
    {
        public StockService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<StockBO>> GetStockList()
        {
            var stocks = await Context.Stocks.ToListAsync();
            List<StockBO> stockBOs = new List<StockBO>();

            foreach (var stock in stocks)
            {
                StockBO stockBO = _mapper.Map<StockBO>(stock); //Instanciar de una clase
                stockBOs.Add(stockBO);
            }
            return stockBOs;
        }
        public StockBO GetStockById(int id)
        {
            return new StockBO();
        }
    }
}