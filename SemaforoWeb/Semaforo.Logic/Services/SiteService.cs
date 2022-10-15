using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Semaforo.Logic.Services
{
    public class SiteService : BaseService
    {
        public SiteService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<SiteBO>> GetSiteList()
        {
            var sites = await Context.Sites.ToListAsync();
            List<SiteBO> siteBOs = new List<SiteBO>();

            foreach (var site in sites)
            {
                SiteBO siteBO = _mapper.Map<SiteBO>(site); //Instanciar de una clase
                siteBOs.Add(siteBO);
            }
            return siteBOs;
        }
        public SiteBO GetSiteById(int id)
        {
            return new SiteBO();
        }
    }
}
