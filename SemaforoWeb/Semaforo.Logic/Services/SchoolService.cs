using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Semaforo.Logic.Services
{
    public class SchoolService : BaseService
    {
        public SchoolService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<SchoolBO>> GetSchoolList()
        {
            var schools = await Context.Schools.ToListAsync();
            List<SchoolBO> schoolBOs = new List<SchoolBO>();

            foreach (var school in schools)
            {
                SchoolBO schoolBO = _mapper.Map<SchoolBO>(school); //Instanciar de una clase
                schoolBOs.Add(schoolBO);
            }
            return schoolBOs;
        }
        public SchoolBO GetSchoolById(int id)
        {
            return new SchoolBO();
        }
    }
}
