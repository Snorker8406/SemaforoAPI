using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semaforo.Logic.Services
{
    public class CatalogService<T, BO> 
        where T : class
        where BO : class
    {
        protected readonly db_9bc4da_semaforoContext Context;
        protected readonly ApplicationUserBO CurrentUser;
        protected readonly IMapper _mapper;

        public CatalogService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser)
        {
            Context = context;
            CurrentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<List<BO>> GetEntityList()
        {
            var entities = await Context.Set<T>().ToListAsync();
            List<BO> BOS = new List<BO>();

            foreach (var entity in entities)
            {
                var BO = _mapper.Map<BO>(entity); //Instanciar de una clase
                BOS.Add(BO);
            }
            return BOS;
        }

        public async Task<BO> GetEntityById(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return _mapper.Map<BO>(entity);
        }

        public async Task<BO> updateEntity(object BO)
        {
            try
            {
                T entity = _mapper.Map<T>(BO);
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                BO response = _mapper.Map<BO>(entity);
                return response;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }
        public async Task<BO> saveEntity(object BO)
        {
            try
            {
                T entity = _mapper.Map<T>(BO);
                Context.Set<T>().Add(entity);
                await Context.SaveChangesAsync();
                BO response = _mapper.Map<BO>(entity);
                return response;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }

        public async Task<int> deleteEntity(int id)
        {
            try
            {
                var entity = await Context.Set<T>().FindAsync(id);
                Context.Remove(entity);
                await Context.SaveChangesAsync();
                return id;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }

    }
}
