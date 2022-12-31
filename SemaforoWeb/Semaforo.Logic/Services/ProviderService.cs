using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Logic.Services
{
    public class ProviderService : BaseService
    {
        public ProviderService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser) : base(context, mapper, currentUser)
        {
        }
        public async Task<List<ProviderBO>> GetProviderList()
        {
            var providers = await Context.Providers.ToListAsync();
            List<ProviderBO> providerBOs = new List<ProviderBO>();

            foreach (var provider in providers)
            {
                ProviderBO providerBO = _mapper.Map<ProviderBO>(provider); //Instanciar de una clase
                providerBOs.Add(providerBO);
            }
            return providerBOs;
        }

        public async Task<ProviderBO> GetProviderById(int id)
        {
            var provider = await Context.Providers.FindAsync(id);
            return _mapper.Map<ProviderBO>(provider);
        }

        public async Task<int> updateProvider(ProviderBO providerBO)
        {
            try
            {
                Provider provider = _mapper.Map<Provider>(providerBO);
                Context.Entry(provider).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return provider.ProviderId;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }
        public async Task<int> saveProvider(ProviderBO providerBO)
        {
            try
            {
                Provider provider = _mapper.Map<Provider>(providerBO);
                Context.Add(provider);
                await Context.SaveChangesAsync();
                return provider.ProviderId;
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }

    }
}
