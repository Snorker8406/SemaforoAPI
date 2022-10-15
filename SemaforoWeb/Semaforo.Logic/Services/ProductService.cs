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
    public class ProductService : BaseService
    {
        public ProductService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<ProductBO>> GetProductList()
        {
            var products = await Context.Products.ToListAsync();
            List<ProductBO> productBOs = new List<ProductBO>();

            foreach (var product in products)
            {
                ProductBO productBO = _mapper.Map<ProductBO>(product); //Instanciar de una clase
                productBOs.Add(productBO);
            }
            return productBOs;
        }
        public ProductBO GetProductById(int id)
        {
            return new ProductBO();
        }
    }
}