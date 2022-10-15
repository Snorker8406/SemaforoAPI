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
        public ClientService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
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
        public async Task<ClientBO> GetClientById(int id)
        {
            var client = await Context.Clients.FindAsync(id);
            return _mapper.Map<ClientBO>(client);
        }

        public async Task<int> updateClient(ClientBO clientBO) {
            try
            {
                Client client = _mapper.Map<Client>(clientBO);
                Context.Entry(client).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return client.ClientId;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }
    }
}
