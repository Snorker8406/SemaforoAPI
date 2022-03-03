using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

namespace Semaforo.Logic.Services
{
    public class BrandService : BaseService
    {
        public BrandService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<BrandBO>> GetBrandList()
        {
            List<Brand> brands = Context.Brands.ToList<Brand>();
            List<BrandBO> brandBOs = new();

            foreach (var brand in brands)
            {
                BrandBO brandBO = _mapper.Map<BrandBO>(brand); //Instanciar de una clase
                brandBOs.Add(brandBO);
            }
            return brandBOs;
        }
        public BrandBO GetBrandById(int id)
        {
            return new BrandBO();
        }
    }
}
