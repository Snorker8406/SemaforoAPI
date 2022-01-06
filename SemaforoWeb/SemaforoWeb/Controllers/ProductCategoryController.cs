using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public ProductCategoryController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<ProducyCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetProductGategories()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            List<ProductCategoryDTO> productCategoryDTOs = new List<ProductCategoryDTO>();

            return productCategoryDTOs;
        }
        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {

            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategory", new { id = productCategory.ProductId }, productCategory);
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
