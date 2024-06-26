using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;

        public IndexModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }


        [BindProperty(SupportsGet = true)]
        public QueryOrderDto QueryOrderDto { get; set; } = default!;

        public IList<Order> Order { get; set; } = new List<Order>();//default!;

        public async Task OnGetAsync()
        {
            var orders = (await _orderBusiness.GetAllOrder()).Data as List<Order>;

            if (QueryOrderDto != null)
            {
                if (QueryOrderDto.OrderId.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderId == QueryOrderDto.OrderId.Value)
                        .ToList();
                }

                if (!string.IsNullOrEmpty(QueryOrderDto.OrderStatus))
                {
                    orders = orders
                        .Where(o => o.OrderStatus.Contains(QueryOrderDto.OrderStatus))
                        .ToList();
                }

                if (!string.IsNullOrEmpty(QueryOrderDto.DeliveryStatus))
                {
                    orders = orders
                        .Where(o => o.DeliveryStatus.Contains(QueryOrderDto.DeliveryStatus))
                        .ToList();
                }

                if (QueryOrderDto.TotalAmount.HasValue)
                {
                    orders = orders
                        .Where(o => o.TotalAmount == QueryOrderDto.TotalAmount.Value)
                        .ToList();
                }

            }

            Order = orders;
        }
    }
}
