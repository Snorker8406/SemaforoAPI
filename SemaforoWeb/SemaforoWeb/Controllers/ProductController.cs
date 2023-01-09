using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SemaforoWeb.DTO.CatalogsDTO;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using Semaforo.Logic.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _productService = new ProductService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<ProductBO>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProductList();
                if (products == null)
                {
                    return null;
                }
                return Catalog<ProductBO>.BuildCatalog("", products, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.ProductId }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
