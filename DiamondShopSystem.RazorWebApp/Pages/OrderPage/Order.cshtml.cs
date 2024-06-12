using DiamondShopSystem.Business.Business.Interfaces;
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

        public List<Data.Models.Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _orderBusiness.GetAllOrder();
            if (result != null)
            {
                Orders = result.Data != null ? (List<Data.Models.Order>)result.Data : new List<Data.Models.Order>();
            }
        }
    }
}