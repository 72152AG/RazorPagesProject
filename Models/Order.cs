using RestaurantThingy.Models;

public class Order
{
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    // Collection navigation property for order items
    public List<OrderItem> Items { get; set; }
}
