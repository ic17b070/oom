using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IProduct
    {
        string Label { get; }
        Measurement Measurement { get; }
        Price Price { get; }
        DateTime ExpirationDate { get; }

        bool HasExpired();
    }
}
