using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semaforo.Web.DTO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Semaforo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly db_9bc4da_semaforoContext _context;

        public AttendanceController(db_9bc4da_semaforoContext context)
        {
            _context = context;
        }

        // GET: api/<AttendanceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetAttendance()
        {
            var attendances = await _context.Clients.ToListAsync();
            List<AttendanceDTO> attendanceDTOs = new List<AttendanceDTO>();

            return attendanceDTOs;
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
