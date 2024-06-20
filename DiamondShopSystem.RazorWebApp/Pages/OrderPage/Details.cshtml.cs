using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;


        public DetailsModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
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
    }
}
