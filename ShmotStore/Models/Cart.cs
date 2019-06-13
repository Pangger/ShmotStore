using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public class Cart
    {
        private List<Product> products = new List<Product>();

        public void AddItem(Product product)
        {
            products.Add(product);

        }

        public void RemoveItem(Product product)
        {
            products.Remove(product);
        }

        public void ClearCart()
        {
            products.Clear();
        }

        public List<Product> GetProdcts()
        {
            return products;
        }
    }
}