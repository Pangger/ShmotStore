using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public class CartViewModel
    {
        public List<Product> Products { get; set; }

        public decimal CartTotal()
        {
            if (Products != null)
            {
                decimal total = 0.0m;

                foreach(var product in Products)
                {
                    total += product.Price;
                }

                return total;
            }
            return 0.0m;
        }
    }
}