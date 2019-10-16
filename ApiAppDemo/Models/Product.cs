using System;
using System.Collections.Generic;

namespace ApiAppDemo.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
