using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using Semaforo.Logic.Services;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Semaforo.Logic;
using Newtonsoft.Json;

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;
        private readonly IMapper _mapper;
        private readonly Dictionary<string, dynamic> _services = new Dictionary<string, dynamic>();
        public CatalogController(db_9bc4da_semaforoContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
            createCatalogServices();
        }
        private void createCatalogServices()
        {
            foreach (var entity in CatalogsConfigs.Entities)
            {
                Type typeModel = Type.GetType("Semaforo.Logic.Models." + entity + ", Semaforo.Logic");
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entity + "BO, Semaforo.Logic");
                Type[] types = { typeModel, typeBO };
                Type genericClass = typeof(CatalogService<,>);
                Type constructedClass = genericClass.MakeGenericType(types);
                object service = Activator.CreateInstance(constructedClass, _context, _mapper, null);
                _services.Add(entity, service);
            }

        }

        [HttpGet("{entity}")]
        public async Task<ActionResult<CatalogDTO<dynamic>>> GetItems(string entity)
        {
            try
            {
                var items = await _services[entity].GetEntityList();
                if (items == null)
                {
                    return null;
                }
                var result = Catalog<dynamic>.BuildCatalog(entity, items, _mapper);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET api/<ProviderController>/5
        [HttpGet("{entity}/{id}")]
        public async Task<dynamic> Get(int id, string entity)
        {
            return await _services[entity].GetEntityById(id);
        }


        // POST api/<ClientController>
        [HttpPost("{entity}")]
        public async Task<IActionResult> PostItem(object dto, string entity)
        {
            try
            {
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entity + "BO, Semaforo.Logic");
                Type typeDTO = Type.GetType("SemaforoWeb.DTO.CatalogsDTO." + entity + "DTO, SemaforoWeb");
                var itemDTO = JsonConvert.DeserializeObject(dto.ToString(), typeDTO);
                var itemBO = _mapper.Map(itemDTO, typeDTO, typeBO);
                dynamic response = await _services[entity].saveEntity(itemBO);
                if (typeBO.GetProperty(entity + "Id").GetValue(response) > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Error at save new " + entity);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        //PUT api/<ClientController>/5
        [HttpPut("{entity}/{id}")]
        public async Task<IActionResult> PutItem(int id, object dto, string entity)
        {
            try
            {
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entity + "BO, Semaforo.Logic");
                Type typeDTO = Type.GetType("SemaforoWeb.DTO.CatalogsDTO." + entity + "DTO, SemaforoWeb");
                var itemDTO = JsonConvert.DeserializeObject(dto.ToString(), typeDTO);
                var itemBO = _mapper.Map(itemDTO, typeDTO, typeBO);
                if (id != (int)typeBO.GetProperty(entity + "Id").GetValue(itemBO))
                {
                    return BadRequest("information inconsistent");
                }

                dynamic response = await _services[entity].updateEntity(itemBO);
                if (typeBO.GetProperty(entity + "Id").GetValue(response) > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }

        }
        [HttpDelete("{entity}/{id}")]
        public async Task<IActionResult> DeleteItem(int id, string entity)
        {
            try
            {
                var deletedId = await _services[entity].deleteEntity(id);
                if (deletedId > 0)
                {
                    return Ok(deletedId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
