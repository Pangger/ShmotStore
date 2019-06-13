using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}