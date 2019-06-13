using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Sex Sex { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Categories = new List<Category>();
            Sizes = new List<Size>();
            Orders = new List<Order>();
        }

    }
}