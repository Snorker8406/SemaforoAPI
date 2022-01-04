using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo.Logic.Services
{
    public class BaseService
    {
        protected readonly db_9bc4da_semaforoContext Context;
        protected readonly UserBO CurrentUser;

        public BaseService(db_9bc4da_semaforoContext context, UserBO currentUser)
        {
            Context = context;
            CurrentUser = currentUser;
        }
    }
}
