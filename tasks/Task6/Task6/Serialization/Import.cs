using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Serialization
{
    class Import
    {
        public static IProduct[] start()
        {
            Console.WriteLine("<<<<<<<<<<<<<<<Deserialization: Importing Objects");
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IProduct[]>(textFromFile, settings);
            return itemsFromFile;
        }
    }
}
