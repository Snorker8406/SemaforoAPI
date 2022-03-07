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
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using SemaforoWeb.DTO.CatalogsDTO.Lib;
using AutoMapper;

namespace SemaforoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolLevelController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly SchoolLevelService _schoolLevelService;
        private readonly IMapper _mapper;

        public SchoolLevelController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _schoolLevelService = new SchoolLevelService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<SchoolLevelBO>>> GetSchoolLevels()
        {
            try
            {
                var schoolLevels = await _schoolLevelService.GetSchoolLevelList();
                if (schoolLevels == null)
                {
                    return null;
                }
                return Catalog<SchoolLevelBO>.BuildCatalog(Catalog<SchoolLevelBO>.SchoolLevelColumnsConfigs, schoolLevels, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<SchoolLevelController>/5
        [HttpGet("{id}")]
        public SchoolLevelBO Get(int id)
        {
            return _schoolLevelService.GetSchoolLevelById(id);
        }

    }
}
