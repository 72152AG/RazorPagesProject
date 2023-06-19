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
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Order> CompletedOrders { get; set; }

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            CompletedOrders = await _context.Orders
                .Include(o => o.Items) // Include the associated items
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
