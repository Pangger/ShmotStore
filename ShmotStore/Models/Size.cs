using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Size()
        {
            Products = new List<Product>();
        }
    }
}