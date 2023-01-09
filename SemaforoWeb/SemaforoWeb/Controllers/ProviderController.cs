using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly ProviderService _providerService;
        private readonly IMapper _mapper;

        public ProviderController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _providerService = new ProviderService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CatalogDTO<ProviderBO>>> GetProviders()
        {
            try
            {
                var providers = await _providerService.GetProviderList();
                if (providers == null)
                {
                    return null;
                }
                var result = Catalog<ProviderBO>.BuildCatalog("Providers", providers, _mapper);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public async Task<ProviderBO> Get(int id)
        {
            return await _providerService.GetProviderById(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> PostProvider(ProviderDTO providerDTO)
        {
            ProviderBO provider = new ProviderBO();
            provider = _mapper.Map<ProviderBO>(providerDTO);
            try
            {
                ProviderBO providerResponse = await _providerService.saveProvider(_mapper.Map<ProviderBO>(providerDTO));
                if (providerResponse.ProviderId > 0)
                {
                    return Ok(providerResponse);
                }
                else
                {
                    return BadRequest("Error at save new Provider");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(int id, ProviderDTO providerDTO)
        {
            if (id != providerDTO.ProviderId)
            {
                return BadRequest("information inconsistent");
            }
            try
            {
                ProviderBO providerResponse = await _providerService.updateProvider(_mapper.Map<ProviderBO>(providerDTO));
                if (providerResponse.ProviderId > 0)
                {
                    return Ok(providerResponse);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            try
            {
                var deletedId = await _providerService.deleteProvider(id);
                if (deletedId > 0)
                {
                    return Ok(deletedId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
