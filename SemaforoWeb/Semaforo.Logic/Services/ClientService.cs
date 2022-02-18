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
    public class ClientService : BaseService
    {
        public ClientService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        {}

        public async Task<List<ClientBO>> GetClientList()
        {
            var clients = await Context.Clients.ToListAsync();
            List<ClientBO> clientBOs = new List<ClientBO>();

            foreach (var client in clients)
            {
                ClientBO clientBO = _mapper.Map<ClientBO>(client); //Instanciar de una clase
                clientBOs.Add(clientBO);
            }
            return clientBOs;
        }
        public ClientBO GetClientById(int id)
        {
            return new ClientBO();
        }
    }
}
