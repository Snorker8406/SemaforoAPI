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
    public class SizeController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly SizeService _sizeService;
        private readonly IMapper _mapper;

        public SizeController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _sizeService = new SizeService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<SizeBO>>> GetSizes()
        {
            try
            {
                var sizes = await _sizeService.GetSizeList();
                if (sizes == null)
                {
                    return null;
                }
                return Catalog<SizeBO>.BuildCatalog("Sizes", sizes, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public async Task<ActionResult<Size>> PostSize(Size size)
        {

            _context.Sizes.Add(size);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSize", new { id = size.SizeId }, size);
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
