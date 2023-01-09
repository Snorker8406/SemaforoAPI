
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semaforo.Logic.BO;
using SemaforoWeb.Profiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Lib
{
    public static class Catalog<T>
    {
        private static string JsonFile = "CatalogConfig.json";
        public static List<CatalogFieldDTO> BuildColumns(object DTO, string tableName)
        {
            JObject configFile = JObject.Parse(File.ReadAllText(JsonFile));
            var tableConfigs = configFile.SelectToken(tableName).Value<object>();
            List<CatalogFieldDTO> columns = JsonConvert.DeserializeObject<List<CatalogFieldDTO>>(tableConfigs.ToString());
            return columns;
        }

        public static CatalogDTO<T> BuildCatalog(string tableName, IEnumerable<T> data, IMapper mapper) {
            CatalogDTO<T> catalog = new CatalogDTO<T>();
            catalog.Columns = BuildColumns(data.FirstOrDefault(), tableName);
            foreach (var item in data.ToList())
            {
                T clientDTO = mapper.Map<T>(item);
                catalog.Data.Add(clientDTO);
            }
            return catalog;
        }
    }
}
