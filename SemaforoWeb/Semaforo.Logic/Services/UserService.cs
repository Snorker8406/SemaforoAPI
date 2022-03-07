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
    public class UserService : BaseService
    {
        public UserService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<UserBO>> GetUserList()
        {
            var users = await Context.Users.ToListAsync();
            List<UserBO> userBOs = new List<UserBO>();

            foreach (var user in users)
            {
                UserBO userBO = _mapper.Map<UserBO>(user); //Instanciar de una clase
                userBOs.Add(userBO);
            }
            return userBOs;
        }
        public UserBO GetUserById(int id)
        {
            return new UserBO();
        }
    }
}
