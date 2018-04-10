using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6
{
    public class DairyProduct : AbstractProduct
    {
        public DairyProduct(string label, Price price, Measurement measurement, DateTime expirationDate) : base(label, price, measurement, expirationDate)
        {
        }
    }
}
