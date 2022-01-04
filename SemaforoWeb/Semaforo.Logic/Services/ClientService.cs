using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Logic.Services
{
    public class ClientService : BaseService
    {
        public ClientService(db_9bc4da_semaforoContext context, UserBO currentUser) : base(context, currentUser)
        {}

        public async Task<List<ClientBO>> GetClientList()
        {
            var clients = await Context.Clients.ToListAsync();
            List<ClientBO> clientBOs = new List<ClientBO>();

            foreach (var client in clients)
            {
                ClientBO clientBO = new ClientBO(); //Instanciar de una clase

                clientBO.ClientId = client.ClientId;
                clientBO.Name = client.Name;
                clientBO.Address = client.Address;
                clientBO.UserId = client.UserId;
                clientBO.Cellphone = client.Cellphone;
                clientBO.Email = client.Email;
                clientBO.AccountDaysLimit = client.AccountDaysLimit;
                clientBO.AccountAmountLimit = client.AccountAmountLimit;
                clientBO.LastModify = client.LastModify;
                clientBO.LastModifiedBy = client.LastModifiedBy;

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
