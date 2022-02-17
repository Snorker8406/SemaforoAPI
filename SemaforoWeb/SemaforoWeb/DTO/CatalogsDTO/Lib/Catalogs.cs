using SemaforoWeb.DTO.CatalogsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Lib
{
    public static class Catalog
    {
        public static string[,] ClientColumnsConfigs = {
                { "ClientId",           "ID",                   "",             "1",    "1",    "1" },
                { "UserId",             "ID",                   "userOptions",  "1",    "1",    "1" },
                { "Name",               "Nombre",               "",             "1",    "0",    "1" },
                { "LastName",           "Apellido Paterno",     "",             "1",    "1",    "0" },
                { "LastNameMother",     "Apellido Materno",     "",             "0",    "1",    "1" }
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
                        catalogField.IsInResponse = (columnsConfigs[i, 5] == "1");
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

        public static CatalogDTO<Object> BuildCatalog(object DTO, string[,] columnsConfigs, List<object> data) {
            if (data == null)
            {
                return null;
            }
            CatalogDTO<Object> catalog = new CatalogDTO<Object>();
            catalog.Columns = Catalog.BuildColumns(data[0], Catalog.ClientColumnsConfigs);

            foreach (var item in data)
            {
                object itemDTO = new ClientDTO();
                itemDTO.ClientId = client.ClientId;
                itemDTO.Name = client.Name;
                itemDTO.LastName = client.LastName;
                itemDTO.LastNameMother = client.LastNameMother;
                catalog.Data.Add(itemDTO);
            }
            return catalog;
        }
    }
}
