using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Logic
{
    public static class CatalogsConfigs
    {
        private static readonly string JsonFile = "CatalogConfig.json";
        public static JObject JConfig { get; private set; }
        public static IList<string> Entities { get; private set; }
        public static void ReadConfigFile() {
            JConfig = JObject.Parse(System.IO.File.ReadAllText(JsonFile));
            Entities = JConfig.Properties().Select(p => p.Name).ToList();
        }
    }
}
