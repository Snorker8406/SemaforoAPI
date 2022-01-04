using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semaforo.Logic.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private ClientService _clientService;

        public ClientController(db_9bc4da_semaforoContext context)
        {
            _context = context;
            _clientService = new ClientService(context, null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientBO>>> GetClients()
        {
            return await _clientService.GetClientList();

        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ClientBO Get(int id)
        {
            return _clientService.GetClientById(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Clients>> PostClient(ClientDTO clientDto)
        {
            Clients client = new Clients();
            client.UserId = clientDto.UserId;
            client.ClientStatusId = clientDto.ClientStatusId;
            client.CreateDate = DateTime.Now;
            client.LastModify = DateTime.Now;
            client.LastModifiedBy = clientDto.LastModifiedBy;
            client.Status = clientDto.Status;
            client.Name = clientDto.Name;
            client.LastName = clientDto.LastName;
            client.LastNameMother = clientDto.LastNameMother;
            client.Gender = clientDto.Gender;
            client.AccountDaysLimit = clientDto.AccountDaysLimit;
            client.AccountAmountLimit = clientDto.AccountAmountLimit;
            client.Address = clientDto.Address;
            client.Cellphone = clientDto.Cellphone;
            client.Whatsapp = clientDto.Whatsapp;
            client.Facebook = clientDto.Facebook;
            client.Email = clientDto.Email;
            client.ProfileImage = clientDto.ProfileImage;
            client.Comments = clientDto.Comments;


            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClients", new { id = client.ClientId }, client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Clients client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
