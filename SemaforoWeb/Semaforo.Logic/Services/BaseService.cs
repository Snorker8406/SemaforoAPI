using AutoMapper;
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
        protected readonly IMapper _mapper;
        public BaseService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser)
        {
            Context = context;
            CurrentUser = currentUser;
            _mapper = mapper;
        }
    }
}
