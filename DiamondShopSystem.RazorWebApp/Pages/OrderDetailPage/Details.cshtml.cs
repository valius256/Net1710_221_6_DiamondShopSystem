using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;

        public DetailsModel(IOrderDetailBusiness orderDetailBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
        }

        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id);
            var orderdetailModel = (orderdetail.Data as OrderDetail);
            if (orderdetailModel == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderdetailModel;
            }
            return Page();
        }
    }
}
