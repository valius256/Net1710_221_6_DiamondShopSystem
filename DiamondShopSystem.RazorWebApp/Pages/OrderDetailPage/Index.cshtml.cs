﻿using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Data.Models;
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
        public QueryOrderDetailsDto QueryOrderDetailDto { get; set; } = default!;

      
        public async Task OnGetAsync()
        {
            var orderDetails = (await _orderDetailBusiness.GetAllOrderDetail()).Data as List<OrderDetail>;

            if (QueryOrderDetailDto != null)
            {
                if (QueryOrderDetailDto.Quantity.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.Quantity == QueryOrderDetailDto.Quantity.Value)
                        .OrderBy(ld => ld.Quantity)
                        .ToList();
                }

                if (QueryOrderDetailDto.Amount.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.Amount == QueryOrderDetailDto.Amount.Value)
                        .ToList();
                }

                if (!string.IsNullOrEmpty(QueryOrderDetailDto.ShipmentTrackingNumber))
                {
                    orderDetails = orderDetails
                        .Where(od => od.ShipmentTrackingNumber.Contains(QueryOrderDetailDto.ShipmentTrackingNumber))
                        .ToList();
                }

                if (QueryOrderDetailDto.ShipmentDate.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.ShipmentDate.Value.Date == QueryOrderDetailDto.ShipmentDate.Value.Date)
                        .ToList();
                }

                if (QueryOrderDetailDto.ProductId.HasValue)
                {
                    orderDetails = orderDetails
                        .Where(od => od.Product.ProductId == QueryOrderDetailDto.ProductId)
                        .ToList();
                }
            }

            OrderDetail = orderDetails;
        }
    }

}
