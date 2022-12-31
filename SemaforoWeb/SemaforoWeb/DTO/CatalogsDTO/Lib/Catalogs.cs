
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
                { "ClientId",           "ID Cliente",           "",             "1",    "1",    "1",},//columnName - Type - IsColumn - IsInForm - IsPrimaryKey
                { "UserId",             "ID Usuario",           "userOptions",  "1",    "1",    "0",},
                { "Name",               "Nombre",               "",             "1",    "1",    "0",},
                { "LastName",           "Apellido Paterno",     "",             "1",    "1",    "0",},
                { "LastNameMother",     "Apellido Materno",     "",             "1",    "1",    "0",}
            };
        public static string[,] ProviderColumnsConfigs = {
                { "ProviderId",         "ID",                   "",             "1",    "1",    "1",},//columnName - Type - IsColumn - IsInForm - IsPrimaryKey
                { "Address",            "Direccion",            "",             "1",    "1",    "0",},
                { "Name",               "Nombre",               "",             "1",    "1",    "0",},
                { "ContactName",        "Contacto",             "",             "1",    "1",    "0",},
                { "Phone",              "Telefono",             "",             "1",    "1",    "0",},
                { "Cellphone",          "Celular",              "",             "1",    "1",    "0",},
                { "BankAccounts",       "Bancos",               "",             "0",    "1",    "0",},
                { "Whatsapp",           "Whatsapp",             "",             "1",    "1",    "0",},
                { "Description",        "Descripcion",          "",             "0",    "1",    "0",},
                { "Website",            "Sitio Web",            "",             "0",    "1",    "0",},
            };

        public static string[,] EmployeeColumnsConfigs = {
                { "EmployeeId",         "ID",                   "",             "1",    "1",    "1",},
                { "UserId",             "User ID",              "userOptions",  "1",    "1",    "0",},
                { "Name",               "Nombre",               "",             "1",    "0",    "0",},
                { "FirstLastName",      "Apellido Paterno",     "",             "1",    "1",    "0",},
                { "SecondLastName",     "Apellido Materno",     "",             "0",    "1",    "0",}
            };

        public static string[,] ProductColumnsConfigs = {
                { "ProductId",          "ID",                   "",             "1",    "1",    "1",},
                { "BrandId",            "Marca",                "userOptions",  "1",    "1",    "0",},
                { "Name",               "Nombre",               "",             "1",    "0",    "0",},
                { "CreateDate",         "Fecha",                "",             "1",    "1",    "0",},
                { "Model",              "Modelo",               "",             "0",    "1",    "0",}
            };

        public static string[,] BrandColumnsConfigs = {
                { "BrandId",            "ID",                   "",             "1",    "1",    "1",},
                { "Name",               "Nombre",               "",             "1",    "1",    "0",},
                { "Description",        "Descripcion",          "",             "1",    "1",    "0",},
            };

        public static string[,] CategoryColumnsConfigs = {
                { "CategoryId",         "ID",                   "",             "1",    "1",    "1",},
                { "Name",               "Nombre",               "",             "1",    "1",    "0",},
                { "Description",        "Descripcion",          "",             "1",    "1",    "0",},
            };

        public static string[,] SizeColumnsConfigs = {
                { "SizeId",             "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] AccountStatusColumnsConfigs = {
                { "AccountStatusId",    "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] AccountTypeColumnsConfigs = {
                { "AccountTypeId",      "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] ClientStatusColumnsConfigs = {
                { "ClientStatusId",     "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] EmbroideryColumnsConfigs = {
                { "EmbroideryId",       "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] ProductComboColumnsConfigs = {
                { "ProductComboId",     "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] SchoolLevelColumnsConfigs = {
                { "SchoolLevelId",      "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] SchoolColumnsConfigs = {
                { "SchoolId",           "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] SiteColumnsConfigs = {
                { "SiteId",             "ID",                   "",             "1",    "1",    "0",},
            };

        public static string[,] UserColumnsConfigs = {
                { "UserId",             "ID",                   "",             "1",    "1",    "0",},
            };

        public static List<CatalogFieldDTO> BuildColumns(object DTO, string[,] columnsConfigs)
        {
            List<CatalogFieldDTO> columns = new List<CatalogFieldDTO>();

            foreach (PropertyInfo prop in DTO.GetType().GetProperties())
            {
                CatalogFieldDTO catalogField = new CatalogFieldDTO();
                catalogField.Name = prop.Name;
                catalogField.Type = (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType).ToString();
                for (int i = 0; i < columnsConfigs.GetLength(0); i++)
                {
                    if (columnsConfigs[i, 0] == prop.Name)
                    {
                        catalogField.Key = prop.Name.FirstCharToLowerCase(); //name of property in data
                        catalogField.Label = columnsConfigs[i, 1];
                        catalogField.ColumnName = columnsConfigs[i, 1];
                        catalogField.Type = columnsConfigs[i, 2] != "" ? columnsConfigs[i, 2] : catalogField.Type;
                        catalogField.IsColumn = (columnsConfigs[i, 3] == "1");
                        catalogField.IsInForm = (columnsConfigs[i, 4] == "1");
                        catalogField.IsPrimaryKey = (columnsConfigs[i, 5] == "1");
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
