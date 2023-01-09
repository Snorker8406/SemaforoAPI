using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly BrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _brandService = new BrandService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<BrandBO>>> GetBrands()
        {
            try
            {
                var brands = await _brandService.GetBrandList();
                if (brands == null)
                {
                    return null;
                }
                return Catalog<BrandBO>.BuildCatalog("", brands, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BrandController>
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
