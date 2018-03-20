using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{

    class DairyProducts : IGoods
    {
        private decimal price;

        public string Label { get; }
        public int Quantity { get; }
        public Unit Unit { get; }
        public decimal Price { get { return price; } }

        public DairyProducts(string label, decimal price, int quantity, Unit unit)
        {
            Label = label;
            this.price = price;
            Quantity = quantity;
            Unit = unit;
        }

        public void UpdatePrice(decimal new_price)
        {
            if (price > 0) price = new_price;
        }
    }
}
