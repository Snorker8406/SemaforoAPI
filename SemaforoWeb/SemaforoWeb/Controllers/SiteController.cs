using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using SemaforoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public SiteController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<SiteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteDTO>>> GetSites()
        {
            var sites = await _context.Sites.ToListAsync();
            List<SiteDTO> siteDTOs = new List<SiteDTO>();

            return siteDTOs;
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
