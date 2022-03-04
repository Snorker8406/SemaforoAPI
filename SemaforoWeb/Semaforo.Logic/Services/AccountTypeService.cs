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
    public class AccountTypeService : BaseService
    {
        public AccountTypeService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<AccountTypeBO>> GetAccountTypeList()
        {
            var accountTypes = await Context.AccountTypes.ToListAsync();
            List<AccountTypeBO> accountTypeBOs = new List<AccountTypeBO>();

            foreach (var accountType in accountTypes)
            {
                AccountTypeBO accountTypeBO = _mapper.Map<AccountTypeBO>(accountType); //Instanciar de una clase
                accountTypeBOs.Add(accountTypeBO);
            }
            return accountTypeBOs;
        }
        public AccountTypeBO GetAccountTypeById(int id)
        {
            return new AccountTypeBO();
        }
    }
}
