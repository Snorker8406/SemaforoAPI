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

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductComboController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly ProductComboService _productComboService;
        private readonly IMapper _mapper;

        public ProductComboController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _productComboService = new ProductComboService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<ProductComboBO>>> GetProductCombos()
        {
            try
            {
                var productCombos = await _productComboService.GetProductComboList();
                if (productCombos == null)
                {
                    return null;
                }
                return Catalog<ProductComboBO>.BuildCatalog(Catalog<ProductComboBO>.ProductComboColumnsConfigs, productCombos, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ProductComboBO Get(int id)
        {
            return _productComboService.GetProductComboById(id);
        }

    }
}
