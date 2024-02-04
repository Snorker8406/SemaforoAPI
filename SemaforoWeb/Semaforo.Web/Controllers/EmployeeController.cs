using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.Services;
using Semaforo.Web.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semaforo.Logic.BO;
using Semaforo.Web.DTO.CatalogsDTO;
using Semaforo.Web.DTO.CatalogsDTO.Catalogs;
using Semaforo.Web.DTO.CatalogsDTO.Lib;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Semaforo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _employeeService = new EmployeeService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<EmployeeBO>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployeeList();
                if (employees == null)
                {
                    return null;
                }
                return Catalog<EmployeeBO>.BuildCatalog("Employees", employees, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {   

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employee.EmployeeId }, employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
