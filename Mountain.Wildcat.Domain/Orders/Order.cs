using System.Collections.Generic;
using System.Linq;

namespace Mountain.Wildcat.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(in => int.Price);
        
    }
}