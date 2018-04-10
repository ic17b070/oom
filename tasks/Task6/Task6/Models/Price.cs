using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Price
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Price(decimal amount, Currency unit)
        {
            Amount = amount > 0 ? amount : throw new ArgumentException("Price must be higher than zero");
            Currency = unit;
        }
    }
}
