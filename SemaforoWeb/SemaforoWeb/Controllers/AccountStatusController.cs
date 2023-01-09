using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaforo.Logic.Services;
using AutoMapper;
using Semaforo.Logic.BO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Lib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountStatusController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly AccountStatusService _accountStatusService;
        private readonly IMapper _mapper;

        public AccountStatusController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _accountStatusService = new AccountStatusService(context, mapper, null);
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<AccountStatusBO>>> GetAccountStatuses()
        {
            try
            {
                var accountStatuses = await _accountStatusService.GetAccountStatusList();
                if (accountStatuses == null)
                {
                    return null;
                }
                return Catalog<AccountStatusBO>.BuildCatalog("", accountStatuses, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<AccountStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountStatusController>
        [HttpPost]
        public async Task<ActionResult<AccountStatus>> PostAccount(AccountStatus accountStatus)
        {

            _context.AccountStatuses.Add(accountStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountStatus", new { id = accountStatus.AccountStatusId }, accountStatus);
        }

        // PUT api/<AccountStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
