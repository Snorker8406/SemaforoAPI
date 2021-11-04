﻿using Microsoft.AspNetCore.Mvc;
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
    public class ProductPictureController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public ProductPictureController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<ProductPictureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPictureDTO>>> GetProductPictures()
        {
            var productPictures = await _context.ProductPictures.ToListAsync();
            List<ProductPictureDTO> productPictureDTOs = new List<ProductPictureDTO>();

            return productPictureDTOs;
        }

        // GET api/<ProductPictureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductPictureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductPictureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductPictureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}