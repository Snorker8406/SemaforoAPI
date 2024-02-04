
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semaforo.Logic;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Semaforo.Web.DTO.CatalogsDTO.Lib
{
    public static class Catalog<T>
    {
        public static CatalogDTO<T> BuildCatalog(string tableName, IEnumerable<T> data, IMapper mapper) {
            CatalogDTO<T> catalog = new CatalogDTO<T>();
            catalog.Name = tableName;
            catalog.Label = CatalogsConfigs.JConfig.SelectToken(tableName + ".label").Value<string>();
            var tableConfigs = CatalogsConfigs.JConfig.SelectToken(tableName + ".columns").Value<object>();
            catalog.Columns = JsonConvert.DeserializeObject<List<CatalogFieldDTO>>(tableConfigs.ToString());
            catalog.Icon = CatalogsConfigs.JConfig.SelectToken(tableName + ".icon").Value<string>();
            catalog.Description = CatalogsConfigs.JConfig.SelectToken(tableName + ".description").Value<string>();
            foreach (var item in data.ToList())
            {
                T clientDTO = mapper.Map<T>(item);
                catalog.Data.Add(clientDTO);
            }
            return catalog;
        }
    }
}
