using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantThingy.Data;
using RestaurantThingy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantThingy.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<string> Products { get; set; }

        public OrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = new List<string>();
        }

        public async Task<IActionResult> OnPostAsync(List<string> products, string name, string street, string city, string phone)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var order = new Order
            {
                Name = name,
                Street = street,
                City = city,
                Phone = phone
                
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var product in products)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    Product = product
                };
                _context.OrderItems.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("OrderConfirmation", new { orderId = order.OrderId });
        }
    }
}
