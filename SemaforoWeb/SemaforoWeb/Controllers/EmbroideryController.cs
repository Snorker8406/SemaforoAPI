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
    public class EmbroideryController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly EmbroideryService _embroideryService;
        private readonly IMapper _mapper;

        public EmbroideryController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _embroideryService = new EmbroideryService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<EmbroideryBO>>> GetEmbroideries()
        {
            try
            {
                var embroideries = await _embroideryService.GetEmbroideryList();
                if (embroideries == null)
                {
                    return null;
                }
                return Catalog<EmbroideryBO>.BuildCatalog(Catalog<EmbroideryBO>.EmbroideryColumnsConfigs, embroideries, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public EmbroideryBO Get(int id)
        {
            return _embroideryService.GetEmbroideryById(id);
        }

    }
}
