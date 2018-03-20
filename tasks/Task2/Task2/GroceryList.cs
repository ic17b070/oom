using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class GroceryList
    {
        private List<Product> p_list = new List<Product>();
        
        public GroceryList()
        {

        }

        private void addItem(Product product)
        {
            p_list.Add(product);
        }
    }
}
