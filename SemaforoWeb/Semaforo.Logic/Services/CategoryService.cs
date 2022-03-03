using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Semaforo.Logic.Models;
using Semaforo.Logic.BO;

namespace Semaforo.Logic.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(db_9bc4da_semaforoContext context, IMapper mapper, UserBO currentUser) : base(context, mapper, currentUser)
        { }

        public async Task<List<CategoryBO>> GetCategoryList()
        {
            var categories = await Context.Categories.ToListAsync();
            List<CategoryBO> categoryBOs = new List<CategoryBO>();

            foreach (var category in categories)
            {
                CategoryBO categoryBO = _mapper.Map<CategoryBO>(category); //Instanciar de una clase
                categoryBOs.Add(categoryBO);
            }
            return categoryBOs;
        }
        public CategoryBO GetCategoryById(int id)
        {
            return new CategoryBO();
        }
    }
}