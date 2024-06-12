using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;

        public DeleteModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }


        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderBusiness.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order.Data as Order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderBusiness.GetOrderById(id);
            if (order != null)
            {
                Order = order.Data as Order;
                await _orderBusiness.DeleteOrder(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
