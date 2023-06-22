using System.ComponentModel.DataAnnotations;

namespace RestaurantThingy.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Product { get; set; }
    }
}

/* refer to Order.cs for explanation */