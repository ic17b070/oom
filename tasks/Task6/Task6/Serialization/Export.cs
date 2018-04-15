using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Serialization
{
    class Export
    {
        public static void start(Object x)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>Serialization: Exporting Objects");
            Console.WriteLine();
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var text = JsonConvert.SerializeObject(x, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            File.WriteAllText(filename, text);
        }
    }
}
