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
    public class EmbroideryService : BaseService
    {
        public EmbroideryService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<EmbroideryBO>> GetEmbroideryList()
        {
            var embroideries = await Context.Embroideries.ToListAsync();
            List<EmbroideryBO> embroideryBOs = new List<EmbroideryBO>();

            foreach (var embroidery in embroideries)
            {
                EmbroideryBO embroideryBO = _mapper.Map<EmbroideryBO>(embroidery); //Instanciar de una clase
                embroideryBOs.Add(embroideryBO);
            }
            return embroideryBOs;
        }
        public EmbroideryBO GetEmbroideryById(int id)
        {
            return new EmbroideryBO();
        }
    }
}
