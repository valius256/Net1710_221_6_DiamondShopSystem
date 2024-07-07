using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;

        public IndexModel(IOrderDetailBusiness orderDetailBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
        }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public QueryOrderDetailDto QueryOrderDetailDto { get; set; } = default!;


        public async Task OnGetAsync()
        {
            var orderDetails = (await _orderDetailBusiness.GetAllOrderDetail()).Data as List<OrderDetail>;

            if (QueryOrderDetailDto != null)
            {
                if (QueryOrderDetailDto.OrderDetailId.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.OrderDetailId == QueryOrderDetailDto.OrderDetailId)
                        .ToList();
                }

                if (QueryOrderDetailDto.OrderId.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.OrderId == QueryOrderDetailDto.OrderId)
                        .ToList();
                }

                if (QueryOrderDetailDto.ProductId.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.ProductId == QueryOrderDetailDto.ProductId)
                        .ToList();
                }

                if (QueryOrderDetailDto.Quantity.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.Quantity == QueryOrderDetailDto.Quantity)
                        .ToList();
                }

                if (!string.IsNullOrEmpty(QueryOrderDetailDto.OrderDetailNote))
                {
                    orderDetails = orderDetails.Where(od => od.OrderDetailNote.Contains(QueryOrderDetailDto.OrderDetailNote)).ToList();
                }


                if (QueryOrderDetailDto.Fee.HasValue)
                {
                    orderDetails = orderDetails.Where(od => od.Fee == QueryOrderDetailDto.Fee).ToList();
                }


                // Take the first 5 records after filtering
                orderDetails = orderDetails.Take(5).ToList();
            }
            else
            {
                // Default behavior when no filters are applied
                orderDetails = orderDetails.Take(5).ToList();
            }

            OrderDetail = orderDetails;
        }


        //public async Task OnGetAsync()
        //{
        //    OrderDetail = (await _orderDetailBusiness.GetAllOrderDetail()).Data as List<OrderDetail> ?? new List<OrderDetail>();
        //}
    }

}
