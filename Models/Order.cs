using RestaurantThingy.Models;

public class Order
{
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public List<OrderItem> Items { get; set; }
}

/* along with OrderItem.cs used to create a blueprint to automatically create a database
using Microsoft.EntityFrameworkCore.SqlServer. REMEMBER TO REBUILD DATABASE WHEN ADDING STUFF HERE 
(view -> other -> package manager) */ 