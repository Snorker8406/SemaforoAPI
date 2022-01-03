using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaforoWeb.DTO;
using SemaforoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;

        public ClientController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            var clients = await _context.Clients.ToListAsync();
            List<ClientDTO> clientDTOs = new List<ClientDTO>();

            foreach (var client in clients)
            {
                ClientDTO clientDTO = new ClientDTO(); //Instanciar de una clase

                clientDTO.ClientId = client.ClientId;
                clientDTO.Name = client.Name;
                clientDTO.Address = client.Address;
                clientDTO.UserId = client.UserId;
                clientDTO.Cellphone = client.Cellphone;
                clientDTO.Email = client.Email;
                clientDTO.AccountDaysLimit = client.AccountDaysLimit;
                clientDTO.AccountAmountLimit = client.AccountAmountLimit;
                clientDTO.LastModify = client.LastModify;
                clientDTO.LastModifiedBy = client.LastModifiedBy;

                clientDTOs.Add(clientDTO);
            }
            return clientDTOs;

        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientDTO clientDto)
        {
            Client client = new Client();
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
        public async Task<IActionResult> PutClient(int id, Client client)
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
