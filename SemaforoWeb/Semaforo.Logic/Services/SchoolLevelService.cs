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
    public class SchoolLevelService : BaseService
    {
        public SchoolLevelService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<SchoolLevelBO>> GetSchoolLevelList()
        {
            var schoolLevels = await Context.SchoolLevels.ToListAsync();
            List<SchoolLevelBO> schoolLevelBOs = new List<SchoolLevelBO>();

            foreach (var schoolLevel in schoolLevels)
            {
                SchoolLevelBO schoolLevelBO = _mapper.Map<SchoolLevelBO>(schoolLevel); //Instanciar de una clase
                schoolLevelBOs.Add(schoolLevelBO);
            }
            return schoolLevelBOs;
        }
        public SchoolLevelBO GetSchoolLevelById(int id)
        {
            return new SchoolLevelBO();
        }
    }
}