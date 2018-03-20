using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var goods = new IGoods[]
            {
                new DairyProducts("Milk", 1.20m, 1, Unit.LITER),
                new DairyProducts("Yoghurt", 0.80m, 250, Unit.GRAMM),
                new MeatProducts("T-Bone Steak", 26.90m, 1, Unit.KILOGRAMM),
                new MeatProducts("Minced Meat", 6.90m, 1, Unit.KILOGRAMM)
            };

            foreach(var x in goods)
            {
                Console.WriteLine($"Item: {x.Label, -15} Price: {x.Price, 5}");
            }
        }
    }
}
