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
    public class EmployeeService : BaseService
    {
        public EmployeeService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<EmployeeBO>> GetEmployeeList()
        {
            var employees = await Context.Employees.ToListAsync();
            List<EmployeeBO> employeeBOs = new List<EmployeeBO>();

            foreach (var employee in employees)
            {
                EmployeeBO employeeBO = _mapper.Map<EmployeeBO>(employee); //Instanciar de una clase
                employeeBOs.Add(employeeBO);
            }
            return employeeBOs;
        }
        public EmployeeBO GetEmployeeById(int id)
        {
            return new EmployeeBO();
        }
    }
}