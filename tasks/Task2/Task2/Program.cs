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
            Product p1 = new Product("Tomaten", 1.20, 500, Unit.GRAMM);
            Product p2 = new Product("Gurken", 0.90, 1, Unit.PIECE);
        }
    }
}
