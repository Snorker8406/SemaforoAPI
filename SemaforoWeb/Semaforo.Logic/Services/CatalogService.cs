using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;

namespace Semaforo.Logic.Services
{
    public class CatalogService<T, BO> 
        where T : class
        where BO : class
    {
        protected readonly db_9bc4da_semaforoContext Context;
        protected readonly ApplicationUserBO CurrentUser;
        protected readonly IMapper _mapper;
        private BO AddOptions(BO bo) {
            try
            {
                var props = typeof(BO).GetProperties().Select(p => p.Name).Where(p => p.IndexOf("_Options") > -1);

                if (props.Count() > 0)
                {
                    var tableConfigs = CatalogsConfigs.JConfig.SelectToken(typeof(T).Name + ".columns").Value<object>();
                    var columns = JsonConvert.DeserializeObject<List<dynamic>>(tableConfigs.ToString());
                    foreach (var field in props)
                    {
                        var columnConfigs = columns.Where(c => c.key == field).FirstOrDefault();
                        if (columnConfigs != null)
                        {
                            string ddEntity = columnConfigs.selectEntity;
                            string ddKey = columnConfigs.selectKey;
                            string ddOption = columnConfigs.selectOption;
                            var rows = Context.GetType().GetProperty(ddEntity).GetValue(Context);
                            IEnumerable<dynamic> options = (IEnumerable<dynamic>)rows;
                            Dictionary<int, string> dic = new Dictionary<int, string>();
                            foreach (var option in options)
                            {
                                int key = option.GetType().GetProperty(ddKey).GetValue(option, null);
                                var val = option.GetType().GetProperty(ddOption).GetValue(option, null);
                                dic.Add(key, val);
                            }
                            bo.GetType().GetProperty(field).SetValue(bo, dic);
                        }
                        //collection.Select
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bo;
        }
        private bool WhereEquals<T>(T obj, string propertyName, int value)
        {
            return typeof(T).GetProperty(propertyName)?.GetValue(obj)?.Equals(value) ?? false;
        }
        private void HandleFiles(T bo, List<string> removedFiles, string entityName)
        {
            try
            {
                if (typeof(BO).GetProperty("Files") != null)
                {
                    List<File> files = _mapper.Map<List<File>>(bo.GetType().GetProperty("Files").GetValue(bo, null));
                    foreach (var file in files)
                    {
                        if (file.FileId == 0)
                            Context.Set<File>().Add(file);
                    }
                }
                if (removedFiles.Any()) {
                    var entityIdPropName = typeof(BO).GetProperties().Select(p => p.Name).Where(p => p.IndexOf(entityName + "Id") > -1).FirstOrDefault();
                    int entityIdValue = (int)bo.GetType().GetProperty(entityIdPropName).GetValue(bo, null);
                    string entityIdSQL = entityIdPropName.Substring(0, entityIdPropName.IndexOf("Id")) + "_ID";
                    var filesToRemove = Context.Files.FromSqlRaw($"SELECT * FROM dbo.FILES WHERE {entityIdSQL} = {entityIdValue} AND File_Name IN (SELECT * FROM STRING_SPLIT('{string.Join(",", removedFiles)}', ','))");
                    var archivesToRemove = Context.Archives.FromSqlRaw($"SELECT * FROM dbo.ARCHIVES WHERE( Archive_ID in ( SELECT Archive_ID FROM dbo.FILES WHERE {entityIdSQL} = {entityIdValue} AND File_Name IN (SELECT * FROM STRING_SPLIT('{string.Join(",", removedFiles)}', ','))))");
                    List<int> archiveIds = archivesToRemove.Select(ar => ar.ArchiveId).ToList();
                    Context.Files.RemoveRange(filesToRemove);
                    Context.SaveChanges();
                    foreach (var id in archiveIds)
                    {
                        var archive = Context.Archives.Find(id);
                        Context.Archives.Remove(archive);
                    }
                    Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public CatalogService(db_9bc4da_semaforoContext context, IMapper mapper, ApplicationUserBO currentUser)
        {
            Context = context;
            CurrentUser = currentUser;
            _mapper = mapper;
        }
        public async Task<List<BO>> GetEntityList()
        {
            List<T> entities = await Context.Set<T>().ToListAsync();
            List<BO> BOS = new List<BO>();

            foreach (var entity in entities)
            {
                var BO = _mapper.Map<BO>(entity); //Instanciar de una clase
                BOS.Add(BO);
            }
            return BOS;
        }

        public async Task<BO> GetEntityById(int id, string entityName)
        {
            BO bo = (BO)Activator.CreateInstance(typeof(BO), null);
            if (id > 0) {
                var parameterExpression = Expression.Parameter(typeof(T), "object");
                var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, entityName + "Id");
                var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(int)));
                var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);
                T entity;
                if (typeof(BO).GetProperty("Files") != null)
                    entity = await Context.Set<T>().Include<T>("Files").FirstOrDefaultAsync<T>(lambdaExpression);
                else entity = await Context.Set<T>().FirstOrDefaultAsync<T>(lambdaExpression);
                bo = _mapper.Map<BO>(entity);
            }
            AddOptions(bo);
            return bo;
        }

        public async Task<FileBO> DownloadFile(int id, string entityName, int fileId)
        {
            try
            {
                if (id > 0 && fileId > 0)
                {
                    var fileEntity = await Context.Files.Include("Archive").FirstOrDefaultAsync(f => f.FileId == fileId);
                    if ((int)fileEntity.GetType().GetProperty(entityName + "Id").GetValue(fileEntity, null) == id)
                    {
                        FileBO fileBO = _mapper.Map<FileBO>(fileEntity);
                        return fileBO;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
                throw;
            }
          
        }

        public async Task<BO> updateEntity(object BO, List<string> removedFiles, string entityName)
        {
            try
            {
                T entity = _mapper.Map<T>(BO);
                HandleFiles(entity, removedFiles, entityName);
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
        public async Task<BO> saveEntity(object BO, string entityName)
        {
            try
            {
                T entity = _mapper.Map<T>(BO);
                Context.Set<T>().Add(entity);
                HandleFiles(entity, new List<string>(), entityName);
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
