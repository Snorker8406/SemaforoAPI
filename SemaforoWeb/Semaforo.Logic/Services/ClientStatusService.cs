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
    public class ClientStatusService : BaseService
    {
        public ClientStatusService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<ClientStatusBO>> GetClientStatusList()
        {
            var clientStatuses = await Context.ClientStatuses.ToListAsync();
            List<ClientStatusBO> clientStatusBOs = new List<ClientStatusBO>();

            foreach (var clientStatus in clientStatuses)
            {
                ClientStatusBO clientStatusBO = _mapper.Map<ClientStatusBO>(clientStatus); //Instanciar de una clase
                clientStatusBOs.Add(clientStatusBO);
            }
            return clientStatusBOs;
        }
        public ClientStatusBO GetClientStatusById(int id)
        {
            return new ClientStatusBO();
        }
    }
}
