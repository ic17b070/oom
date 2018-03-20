using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("Tomaten", 1.20m, 500, Unit.GRAMM);
            Product p2 = new Product("Gurken", 0.90m, 1, Unit.PIECE);

            Console.WriteLine($"Artikel: {p1.Label,-10} Preis: EUR {p1.Price}");

            Console.WriteLine($"Artikel: {p2.Label,-10} Preis: EUR {p2.Price}");
            p2.UpdatePrice(0.99m);
            Console.WriteLine($"Artikel: {p2.Label,-10} Preis: EUR {p2.Price}");

        }
    }
}
