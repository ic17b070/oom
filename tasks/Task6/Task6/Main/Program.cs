using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Task6.Serialization;

namespace Task6
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var products = initProducts();

            Console.WriteLine("All Products:");
            products.ForEach(p => Console.WriteLine($"Item: {p.Label,-15} Price: {p.Price.Amount,5} per {p.Measurement.Amount,8:0.00} {p.Measurement.Unit}"));
            Console.WriteLine();


            Console.WriteLine("Expired Products:");
            products.Where(p => p.HasExpired() == true).ForEach(p => { Console.WriteLine(p); });
            Console.WriteLine();

            Export.start(products);

            Console.WriteLine("Reseting products list to empty array");
            Console.WriteLine();
            products = new IProduct[]{};

            products = Import.start();

            Console.WriteLine("All Products:");
            products.ForEach(p => Console.WriteLine($"Item: {p.Label,-15} Price: {p.Price.Amount,5} per {p.Measurement.Amount,8:0.00} {p.Measurement.Unit}"));
            Console.WriteLine();

            var producer = new Subject<IProduct>();
            producer.Subscribe(x => Console.WriteLine($"Push one product every second: {x}"));

            foreach(var x in products)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(x);
            }
        }

        static void ForEach<T>(this IEnumerable<T> xs, Action<T> a)
        {
            foreach (var x in xs) a(x);
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
    }
}

//IEnumerable<T> Do<T>(this IEnumerable<T> xs, Action<T> a)
//{
//    foreach (var x in xs)
//    {
//        a(x);
//        yield return x;
//    }
//}