using Microsoft.EntityFrameworkCore;
using RestaurantThingy.Models;
using System.Collections.Generic;

namespace RestaurantThingy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
