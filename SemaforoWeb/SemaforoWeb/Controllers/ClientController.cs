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
using System.Linq;
using SemaforoWeb.DTO.CatalogsDTO;
using System.Reflection;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using SemaforoWeb.DTO.CatalogsDTO.Lib;

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

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<ClientDTO>>> GetClients2()
        {
            var clients = await _clientService.GetClientList();
            CatalogDTO<ClientDTO> catalog = new CatalogDTO<ClientDTO>();
            catalog.Columns = Catalogs.BuildColumns(clients[0], Catalogs.clientColumnsConfigs);

            //string[,] columns = {
            //    { "ClientId",           "ID",                   "",             "1",    "1",    "1" },
            //    { "UserId",             "ID",                   "userOptions",  "1",    "1",    "1" },
            //    { "Name",               "Nombre",               "",             "1",    "0",    "1" },
            //    { "LastName",           "Apellido Paterno",     "",             "1",    "1",    "0" },
            //    { "LastNameMother",     "Apellido Materno",     "",             "0",    "1",    "1" }
            //};

            //foreach (PropertyInfo prop in clients[0].GetType().GetProperties())
            //{
            //    CatalogFieldDTO catalogField = new CatalogFieldDTO();
            //    catalogField.Name = prop.Name;
            //    catalogField.Type = (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType).ToString();
            //    var x = columns.GetLength(0);
            //    //var fieldSettings = columns[0].Where(c => c.ToString() == prop.Name);
            //    for (int i = 0; i < columns.GetLength(0); i++)
            //    {
            //        if (columns[i, 0] == prop.Name) {
            //            catalogField.ColumnName = columns[i, 1];
            //            catalogField.Type = columns[i, 2] != "" ? columns[i, 2] : catalogField.Type;
            //            catalogField.IsColumn = (columns[i, 3] == "1");
            //            catalogField.IsInForm = (columns[i, 4] == "1");
            //            catalogField.IsInResponse = (columns[i, 5] == "1");
            //            break;
            //        }
            //    }

            //    //if (type == typeof(DateTime))
            //    //{
            //    //    Console.WriteLine(prop.GetValue(clients[0], null).ToString());
            //    //}

            //    catalog.Columns.Add(catalogField);
            //};

            foreach (var client in clients)
            {
                ClientDTO clientDTO = new ClientDTO();
                clientDTO.ClientId = client.ClientId;
                clientDTO.Name = client.Name;
                clientDTO.LastName = client.LastName;
                clientDTO.LastNameMother = client.LastNameMother;
                catalog.Data.Add(clientDTO);
            }
            return catalog; 


        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ClientBO Get(int id)
        {
            return _clientService.GetClientById(id);
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
