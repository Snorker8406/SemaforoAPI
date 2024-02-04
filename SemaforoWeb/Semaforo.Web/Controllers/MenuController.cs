using Microsoft.AspNetCore.Mvc;
using Semaforo.Logic;
using Semaforo.Web.DTO;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Semaforo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/<MenuController>
        [HttpGet]
        public List<MenuOptionsDTO> Get()
        {
            List<MenuOptionsDTO> menu = new List<MenuOptionsDTO>();
            MenuOptionsDTO option = new MenuOptionsDTO();
            option.Category = "catalog";
            option.Label = "Catalogos";
            option.subOptions = new List<string>();
            foreach (var entity in CatalogsConfigs.Entities)
            {
                option.subOptions.Add(entity);
            }
            menu.Add(option);
            return menu;
        }

    }
}
