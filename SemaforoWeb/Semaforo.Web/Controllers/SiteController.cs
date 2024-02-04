using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semaforo.Web.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaforo.Logic.Services;
using AutoMapper;
using Semaforo.Web.DTO.CatalogsDTO.Lib;
using Semaforo.Logic.BO;
using Semaforo.Web.DTO.CatalogsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Semaforo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly SiteService _siteService;
        private readonly IMapper _mapper;

        public SiteController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _siteService = new SiteService(context, mapper, null);
            _mapper = mapper;
        }

        // GET: api/<SiteController>
        [HttpGet]
        public async Task<ActionResult<CatalogDTO<SiteBO>>> GetSites()
        {
            try
            {
                var sites = await _siteService.GetSiteList();
                if (sites == null)
                {
                    return null;
                }
                return Catalog<SiteBO>.BuildCatalog("", sites, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SiteController>
        [HttpPost]
        public async Task<ActionResult<Site>> PostAccount(Site site)
        {

            _context.Sites.Add(site);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = site.SiteId }, site);
        }


        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
