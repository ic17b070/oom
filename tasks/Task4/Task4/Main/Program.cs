using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var goods = new IProduct[]
            {
                new DairyProduct("Milk", new Price (1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018,04,03)),
                new DairyProduct("Yoghurt", new Price (0.60m, Currency.EUR), new Measurement(250, Unit.MILILITER), new DateTime(2018,04,14)),
                new MeatProduct("Steak", new Price (19.90m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), new DateTime(2018,04,02)),
                new MeatProduct("Minced Meat", new Price (8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), new DateTime(2018,04,01))
            };

            foreach (var x in goods)
            {
                Console.WriteLine($"Item: {x.Label, -15} Price: {x.Price.Amount, 5} per {x.Measurement.Amount,8:0.00} {x.Measurement.Unit}");
                
            }

            Console.WriteLine();
            Console.WriteLine("Expired Products:");
            goods.Where(g => g.HasExpired() == true).ToList().ForEach(g => { Console.WriteLine(g); });

            serialize(goods);

            var goods_deserialized = deserialize();
            
            foreach(var x in goods_deserialized)
            {
                Console.WriteLine("Imported Objects");
                Console.WriteLine($"Item: {x.Label,-15} Price: {x.Price.Amount,5} per {x.Measurement.Amount,8:0.00} {x.Measurement.Unit}");

            }
        }

        static void serialize(Object x)
        {
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var text = JsonConvert.SerializeObject(x, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            File.WriteAllText(filename, text);
        }

        static IProduct[] deserialize()
        {
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IProduct[]>(textFromFile, settings);
            return itemsFromFile;
        }

    }
}
