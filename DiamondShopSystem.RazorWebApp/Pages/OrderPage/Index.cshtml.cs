using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly Net1710_221_6_DiamondShopSystemContext _context;



        public IndexModel(Net1710_221_6_DiamondShopSystemContext context)
        {
            _context = context;
        }



        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
