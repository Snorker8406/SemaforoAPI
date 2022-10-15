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
    public class AccountStatusService : BaseService
    {
        public AccountStatusService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<AccountStatusBO>> GetAccountStatusList()
        {
            var accountStatuses = await Context.AccountStatuses.ToListAsync();
            List<AccountStatusBO> accountStatusBOs = new List<AccountStatusBO>();

            foreach (var accountStatus in accountStatuses)
            {
                AccountStatusBO accountStatusBO = _mapper.Map<AccountStatusBO>(accountStatus); //Instanciar de una clase
                accountStatusBOs.Add(accountStatusBO);
            }
            return accountStatusBOs;
        }
        public AccountStatusBO GetAccountStatusById(int id)
        {
            return new AccountStatusBO();
        }
    }
}
