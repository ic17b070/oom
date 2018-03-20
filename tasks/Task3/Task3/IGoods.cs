using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IGoods
    {

        string Label { get; }
        int Quantity { get; }
        Unit Unit { get; }
        decimal Price { get; }

        void UpdatePrice(decimal new_price);
    }
}
