﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using Semaforo.Logic.Services;
using Semaforo.Web.DTO.CatalogsDTO.Lib;
using Semaforo.Web.DTO.CatalogsDTO;
using Semaforo.Web.DTO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Semaforo.Logic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Semaforo.Web.Common;

namespace Semaforo.Web.Controllers
{
    [Authorize]
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
            foreach (var entityName in CatalogsConfigs.Entities)
            {
                Type typeModel = Type.GetType("Semaforo.Logic.Models." + entityName + ", Semaforo.Logic");
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entityName + "BO, Semaforo.Logic");
                Type[] types = { typeModel, typeBO };
                Type genericClass = typeof(CatalogService<,>);
                Type constructedClass = genericClass.MakeGenericType(types);
                object service = Activator.CreateInstance(constructedClass, _context, _mapper, null);
                _services.Add(entityName, service);
            }

        }

        [HttpGet("{entityName}")]
        public async Task<ActionResult<CatalogDTO<dynamic>>> GetItems(string entityName)
        {
            try
            {
                CatalogsConfigs.ReadConfigFile(); // esta linea es solo para desarrollo
                var items = await _services[entityName].GetEntityList();
                if (items == null)
                {
                    return null;
                }
                var result = Catalog<dynamic>.BuildCatalog(entityName, items, _mapper);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET api/<ProviderController>/5
        [HttpGet("{entityName}/{id}")]
        public async Task<dynamic> Get(int id, string entityName)
        {
            return await _services[entityName].GetEntityById(id, entityName);
        }

        //GET api/<ProviderController>/5/DownloadFile/1
        [HttpGet("{entityName}/{id}/DownloadFile/{fileId}")]
        public async Task<IActionResult> DownloadFile(int id, string entityName, int fileId)
        {
            FileBO fileBo = await _services[entityName].DownloadFile(id, entityName, fileId);
            var content = new MemoryStream(fileBo.Archive);
            return File(content, fileBo.ContentType, fileBo.FileName);
        }


        // POST api/<ClientController>
        [HttpPost("{entityName}")]
        public async Task<IActionResult> PostItem(
            string entityName,
            [FromForm] string dto,
            [FromForm(Name = "singleImages")] List<IFormFile> singleImages,
            [FromForm(Name = "gallery")] List<IFormFile> gallery,
            [FromForm(Name = "files")] List<IFormFile> files)
        {
            try
            {
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entityName + "BO, Semaforo.Logic");
                Type typeDTO = Type.GetType("Semaforo.Web.DTO.CatalogsDTO." + entityName + "DTO, Semaforo.Web");
                var itemDTO = JsonConvert.DeserializeObject(dto.ToString(), typeDTO);
                if (gallery.Any())
                {
                    typeDTO.GetProperty("Gallery").SetValue(itemDTO, gallery);
                }
                if (files.Any())
                {
                    List<FileDTO> filesDTO = new List<FileDTO>();
                    foreach (var file in files)
                    {
                        FileDTO fileDTO = new FileDTO();
                        fileDTO.GetType().GetProperty(entityName + "Id").SetValue(fileDTO, 0);
                        _mapper.Map(file, fileDTO);
                        filesDTO.Add(fileDTO);
                    }
                    typeDTO.GetProperty("Files").SetValue(itemDTO, filesDTO);
                }
                var itemBO = _mapper.Map(itemDTO, typeDTO, typeBO);
                if (singleImages.Any())
                {
                    foreach (var image in singleImages)
                    {
                        itemBO.GetType().GetProperty(Shared.FirstCharToUpper(image.FileName)).SetValue(itemBO, Shared.mapFile(image));
                    }
                }
                dynamic response = await _services[entityName].saveEntity(itemBO, entityName);

                if (typeBO.GetProperty(entityName + "Id").GetValue(response) > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Error at save new " + entityName);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        //PUT api/<ClientController>/5
        [HttpPut("{entityName}/{id}")]
        public async Task<IActionResult> PutItem(
            int id,
            string entityName,
            [FromForm] string dto,
            [FromForm(Name = "singleImages")] List<IFormFile> singleImages,
            [FromForm(Name = "gallery")] List<IFormFile> gallery,
            [FromForm(Name = "files")] List<IFormFile> files,
            [FromForm(Name = "removedFiles")] List<string> removedFiles)
        {
            try
            {
                Type typeBO = Type.GetType("Semaforo.Logic.BO." + entityName + "BO, Semaforo.Logic");
                Type typeDTO = Type.GetType("Semaforo.Web.DTO.CatalogsDTO." + entityName + "DTO, Semaforo.Web");
                var itemDTO = JsonConvert.DeserializeObject(dto.ToString(), typeDTO);
                if (gallery.Any())
                {
                    typeDTO.GetProperty("Gallery").SetValue(itemDTO, gallery);
                }
                if (files.Any())
                {
                    List<FileDTO> filesDTO = new List<FileDTO>();
                    foreach (var file in files)
                    {
                        FileDTO fileDTO = new FileDTO();
                        fileDTO.GetType().GetProperty(entityName + "Id").SetValue(fileDTO, id);
                        _mapper.Map(file, fileDTO);
                        filesDTO.Add(fileDTO);
                    }
                    typeDTO.GetProperty("Files").SetValue(itemDTO, filesDTO);
                }
                var itemBO = _mapper.Map(itemDTO, typeDTO, typeBO);
                if (singleImages.Any())
                {
                    foreach (var image in singleImages)
                    {
                        itemBO.GetType().GetProperty(Shared.FirstCharToUpper(image.FileName)).SetValue(itemBO, Shared.mapFile(image));
                    }
                }
                if (id != (int)typeBO.GetProperty(entityName + "Id").GetValue(itemBO))
                {
                    return BadRequest("information inconsistent");
                }
                dynamic response = await _services[entityName].updateEntity(itemBO, removedFiles, entityName);
                if (typeBO.GetProperty(entityName + "Id").GetValue(response) > 0)
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
        [HttpDelete("{entityName}/{id}")]
        public async Task<IActionResult> DeleteItem(int id, string entityName)
        {
            try
            {
                var deletedId = await _services[entityName].deleteEntity(id);
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