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
            try
            {
                Employee employee = _mapper.Map<Employee>(newUser);
                Context.Employees.Add(employee);
                await Context.SaveChangesAsync();

                return employee.EmployeeId;
            }
            catch (Exception ex)
            {

                return 0;
            }
            
            
        }
        public async Task<ApplicationUserBO> getUserInfoFromEmployee(string userId)
        {
            try
            {
                Employee employee = await Context.Employees.FirstOrDefaultAsync(e => e.AppUserId == userId);
                ApplicationUserBO applicationUserBO = _mapper.Map<ApplicationUserBO>(employee);
                return applicationUserBO;
            }
            catch (Exception)
            {
                throw;
            }


        }
        public async Task<int> updateFacebookImage(int employeeId, byte[] image)
        {
            try
            {
                Employee employee = await Context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                employee.FacebookProfileImage = image;
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
