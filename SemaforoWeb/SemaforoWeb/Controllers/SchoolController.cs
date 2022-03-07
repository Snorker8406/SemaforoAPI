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
    public class SchoolController : ControllerBase
    {

        private readonly db_9bc4da_semaforoContext _context;
        private readonly SchoolService _schoolService;
        private readonly IMapper _mapper;

        public SchoolController(db_9bc4da_semaforoContext context, IMapper mapper)
        {
            _context = context;
            _schoolService = new SchoolService(context, mapper, null);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CatalogDTO<SchoolBO>>> GetSchools()
        {
            try
            {
                var schools = await _schoolService.GetSchoolList();
                if (schools == null)
                {
                    return null;
                }
                return Catalog<SchoolBO>.BuildCatalog(Catalog<SchoolBO>.SchoolColumnsConfigs, schools, _mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public SchoolBO Get(int id)
        {
            return _schoolService.GetSchoolById(id);
        }

    }
}
