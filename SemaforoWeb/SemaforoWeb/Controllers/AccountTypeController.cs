using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO.CatalogsDTO;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly AccountTypeService _accountTypeService;
        private readonly IMapper _mapper;

        public AccountTypeController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _accountTypeService = new AccountTypeService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<AccountTypeBO>>> GetAccountTypes()
        {
            try
            {
                var accountTypes = await _accountTypeService.GetAccountTypeList();
                if (accountTypes == null)
                {
                    return null;
                }
                return Catalog<AccountTypeBO>.BuildCatalog("", accountTypes, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<AccountTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountTypeController>
        [HttpPost]
        public async Task<ActionResult<AccountType>> PostAccountType(AccountType accountType)
        {

            _context.AccountTypes.Add(accountType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountType", new { id = accountType.AccountTypeId }, accountType);
        }

        // PUT api/<AccountTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
