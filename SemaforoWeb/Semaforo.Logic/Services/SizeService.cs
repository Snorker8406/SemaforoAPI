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
    public class SizeService : BaseService
    {
        public SizeService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<SizeBO>> GetSizeList()
        {
            var sizes = await Context.Sizes.ToListAsync();
            List<SizeBO> sizeBOs = new List<SizeBO>();

            foreach (var size in sizes)
            {
                SizeBO sizeBO = _mapper.Map<SizeBO>(size); //Instanciar de una clase
                sizeBOs.Add(sizeBO);
            }
            return sizeBOs;
        }
        public SizeBO GetSizeById(int id)
        {
            return new SizeBO();
        }
    }
}
