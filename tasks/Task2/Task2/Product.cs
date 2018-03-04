using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    enum Unit
    {
        PIECE = 1,
        LITER = 2,
        GRAMM = 3
    }

    class Product
    {
        private String label;
        private Double price;
        private Int32 quantity;
        private Unit p_unit;

        public Decimal Label { get; }
        public Double Price { get; }
        public Int32 Quantity { get; }
        public Unit Unit { get; }

        public Product(String label, Double m_price, Int32 quantity, Unit p_unit)
        {
            this.label = label;
            this.price = m_price;
            this.quantity = quantity;
            this.p_unit = p_unit;
        }
    }
}
