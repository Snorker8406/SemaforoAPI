using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.Services;
using Semaforo.Web.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semaforo.Logic.BO;
using Semaforo.Web.DTO.CatalogsDTO;
using Semaforo.Web.DTO.CatalogsDTO.Catalogs;
using Semaforo.Web.DTO.CatalogsDTO.Lib;
using AutoMapper;

namespace Semaforo.Web.Controllers
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
                return Catalog<EmbroideryBO>.BuildCatalog("", embroideries, _mapper);
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
