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
    public class ProductComboService : BaseService
    {
        public ProductComboService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<ProductComboBO>> GetProductComboList()
        {
            var productCombos = await Context.ProductCombos.ToListAsync();
            List<ProductComboBO> productComboBOs = new List<ProductComboBO>();

            foreach (var productCombo in productCombos)
            {
                ProductComboBO productComboBO = _mapper.Map<ProductComboBO>(productCombo); //Instanciar de una clase
                productComboBOs.Add(productComboBO);
            }
            return productComboBOs;
        }
        public ProductComboBO GetProductComboById(int id)
        {
            return new ProductComboBO();
        }
    }
}