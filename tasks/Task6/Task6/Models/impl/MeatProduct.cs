using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6
{
    public class MeatProduct : AbstractProduct
    {
        public MeatProduct(string label, Price price, Measurement measurement, DateTime expirationDate) : base(label, price, measurement, expirationDate)
        {
        }
    }
}
