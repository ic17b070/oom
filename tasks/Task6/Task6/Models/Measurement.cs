using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public enum Unit
    {
        PIECE = 1,
        MILILITER = 2,
        LITER = 3,
        GRAMM = 4,
        KILOGRAMM = 5
    }

    public class Measurement
    {
        public decimal Amount { get;}
        public Unit Unit { get;}

        public Measurement(decimal amount, Unit unit)
        {
            Amount = amount > 0 ? amount : throw new ArgumentException("Amount must be higher than zero");
            Unit = unit;
        }
    }
}
