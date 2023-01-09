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
    public class ClientStatusController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly ClientStatusService _clientStatusService;
        private readonly IMapper _mapper;

        public ClientStatusController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _clientStatusService = new ClientStatusService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<ClientStatusBO>>> GetClientStatuses()
        {
            try
            {
                var clientStatuses = await _clientStatusService.GetClientStatusList();
                if (clientStatuses == null)
                {
                    return null;
                }
                return Catalog<ClientStatusBO>.BuildCatalog("", clientStatuses, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ClientStatusBO Get(int id)
        {
            return _clientStatusService.GetClientStatusById(id);
        }

    }
}
