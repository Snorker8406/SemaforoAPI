using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _categoryService = new CategoryService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<CategoryBO>>> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategoryList();
                if (categories == null)
                {
                    return null;
                }
                return Catalog<CategoryBO>.BuildCatalog(Catalog<CategoryBO>.CategoryColumnsConfigs, categories, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
