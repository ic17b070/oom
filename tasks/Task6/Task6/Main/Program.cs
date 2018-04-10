using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            var goods = initProducts();

            printAllProducts(goods);
            printExpiredProducts(goods);

            serialize(goods);

            Console.WriteLine("Deserialized Products:");
            printAllProducts(deserialize());
        }

        static void serialize(Object x)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>Serialization: Exporting Objects");
            Console.WriteLine();
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var text = JsonConvert.SerializeObject(x, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            File.WriteAllText(filename, text);
        }

        static IProduct[] deserialize()
        {
            Console.WriteLine("<<<<<<<<<<<<<<<Deserialization: Importing Objects");
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "goods.json");
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IProduct[]>(textFromFile, settings);
            return itemsFromFile;
        }

        static IProduct[] initProducts()
        {
            return new IProduct[]
            {
                new DairyProduct("Milk", new Price (1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018,04,03)),
                new DairyProduct("Yoghurt", new Price (0.60m, Currency.EUR), new Measurement(250, Unit.MILILITER), new DateTime(2018,04,14)),
                new MeatProduct("Steak", new Price (19.90m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), new DateTime(2018,04,02)),
                new MeatProduct("Minced Meat", new Price (8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), new DateTime(2018,04,01))
            };
        }

        static void printAllProducts(IProduct[] productList)
        {
            Console.WriteLine("All Products:");
            productList.ToList().ForEach(p => Console.WriteLine($"Item: {p.Label,-15} Price: {p.Price.Amount,5} per {p.Measurement.Amount,8:0.00} {p.Measurement.Unit}"));
            Console.WriteLine();
        }
        static void printExpiredProducts(IProduct[] productList)
        {
            Console.WriteLine("Expired Products:");
            productList.Where(p => p.HasExpired() == true).ToList().ForEach(p => { Console.WriteLine(p); });
            Console.WriteLine();
        }

    }
}
