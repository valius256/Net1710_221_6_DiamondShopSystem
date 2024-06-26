using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

                // Filter by OrderDate range
                if (QueryOrderDto.OrderDateFrom.HasValue && QueryOrderDto.OrderDateTo.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate >= QueryOrderDto.OrderDateFrom.Value && o.OrderDate <= QueryOrderDto.OrderDateTo.Value)
                        .ToList();
                }
                else if (QueryOrderDto.OrderDateFrom.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate >= QueryOrderDto.OrderDateFrom.Value)
                        .ToList();
                }
                else if (QueryOrderDto.OrderDateTo.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderDate <= QueryOrderDto.OrderDateTo.Value)
                        .ToList();
                }
                if (QueryOrderDto.CustomerId.HasValue)
                {
                    orders = orders
                        .Where(o => o.OrderId == QueryOrderDto.CustomerId.Value)
                        .ToList();
                }
            }

            Order = orders;
        }

    }
}
