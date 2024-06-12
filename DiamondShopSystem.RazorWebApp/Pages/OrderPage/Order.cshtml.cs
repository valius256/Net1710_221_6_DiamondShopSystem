using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class OrderModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        public List<Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _orderBusiness.GetAllOrder();
            if (result != null)
            {
                Orders = result.Data != null ? (List<Order>)result.Data : new List<Order>();
            }
        }
    }
}