using System;
using System.Collections.Generic;

namespace ApiAppDemo.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public double? Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
