
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Semaforo.Logic.BO;
using SemaforoWeb.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Lib
{
    public static class Catalog<T>
    {
        public static string[,] ClientColumnsConfigs = {
                { "ClientId",           "ID",                   "",             "1",    "1"},
                { "UserId",             "ID",                   "userOptions",  "1",    "1"},
                { "Name",               "Nombre",               "",             "1",    "0"},
                { "LastName",           "Apellido Paterno",     "",             "1",    "1"},
                { "LastNameMother",     "Apellido Materno",     "",             "0",    "1"}
            };

        public static string[,] EmployeeColumnsConfigs = {
                { "ClientId",           "ID",                   "",             "1",    "1"},
                { "UserId",             "ID",                   "userOptions",  "1",    "1"},
                { "Name",               "Nombre",               "",             "1",    "0"},
                { "LastName",           "Apellido Paterno",     "",             "1",    "1"},
                { "LastNameMother",     "Apellido Materno",     "",             "0",    "1"}
            };

        public static string[,] ProductColumnsConfigs = {
                { "ClientId",           "ID",                   "",             "1",    "1"},
                { "UserId",             "ID",                   "userOptions",  "1",    "1"},
                { "Name",               "Nombre",               "",             "1",    "0"},
                { "LastName",           "Apellido Paterno",     "",             "1",    "1"},
                { "LastNameMother",     "Apellido Materno",     "",             "0",    "1"}
            };

        public static string[,] BrandColumnsConfigs = {
                { "BrandId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] CategoryColumnsConfigs = {
                { "CategoryId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] StockColumnsConfigs = {
                { "StockId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] SizeColumnsConfigs = {
                { "SizeId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] AccountStatusColumnsConfigs = {
                { "AccountStatusId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] AccountTypeColumnsConfigs = {
                { "AccountTypeId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] ClientStatusColumnsConfigs = {
                { "ClientStatusId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] EmbroideryColumnsConfigs = {
                { "EmbroideryId",           "ID",                   "",             "1",    "1"},
            };

        public static string[,] ProductComboColumnsConfigs = {
                { "ProductComboId",           "ID",                   "",             "1",    "1"},
            };


        public static List<CatalogFieldDTO> BuildColumns(object DTO, string[,] columnsConfigs)
        {
            List<CatalogFieldDTO> columns = new List<CatalogFieldDTO>();

            foreach (PropertyInfo prop in DTO.GetType().GetProperties())
            {
                CatalogFieldDTO catalogField = new CatalogFieldDTO();
                catalogField.Name = prop.Name;
                catalogField.Type = (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType).ToString();
                var x = columnsConfigs.GetLength(0);
                for (int i = 0; i < columnsConfigs.GetLength(0); i++)
                {
                    if (columnsConfigs[i, 0] == prop.Name)
                    {
                        catalogField.ColumnName = columnsConfigs[i, 1];
                        catalogField.Type = columnsConfigs[i, 2] != "" ? columnsConfigs[i, 2] : catalogField.Type;
                        catalogField.IsColumn = (columnsConfigs[i, 3] == "1");
                        catalogField.IsInForm = (columnsConfigs[i, 4] == "1");
                        break;
                    }
                }
                //if (type == typeof(DateTime))
                //{
                //    Console.WriteLine(prop.GetValue(clients[0], null).ToString());
                //}

                columns.Add(catalogField);
            };
            return columns;
        }

        public static CatalogDTO<T> BuildCatalog(string[,] columnsConfigs, IEnumerable<T> data, IMapper mapper) {
            CatalogDTO<T> catalog = new CatalogDTO<T>();
            catalog.Columns = BuildColumns(data.FirstOrDefault(), columnsConfigs);
            foreach (var item in data.ToList())
            {
                T clientDTO = mapper.Map<T>(item);
                catalog.Data.Add(clientDTO);
            }
            return catalog;
        }
    }
}
