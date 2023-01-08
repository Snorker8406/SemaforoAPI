﻿using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Semaforo.Logic.Services
{
    public class AuthService : BaseService
    {
        public AuthService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<ApplicationUserBO>> GetUserList()
        {
            var users = await Context.Users.ToListAsync();
            List<ApplicationUserBO> userBOs = new List<ApplicationUserBO>();

            foreach (var user in users)
            {
                ApplicationUserBO userBO = _mapper.Map<ApplicationUserBO>(user); //Instanciar de una clase
                userBOs.Add(userBO);
            }
            return userBOs;
        }
        public ApplicationUserBO GetUserById(int id)
        {
            return new ApplicationUserBO();
        }

        public async Task<int> RegisterApplicationUser(ApplicationUserBO newUser) {
            Employee employee = _mapper.Map<Employee>(newUser);
            Context.Employees.Add(employee);
            await Context.SaveChangesAsync();

            return newUser.EmployeeId;
            
        }
    }
}