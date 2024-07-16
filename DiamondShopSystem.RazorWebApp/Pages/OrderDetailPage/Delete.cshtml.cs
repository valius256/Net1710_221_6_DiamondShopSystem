using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;

        public DeleteModel(IOrderDetailBusiness orderDetailBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id);
            var orderDetailModel = (orderdetail.Data as OrderDetail);

            if (orderDetailModel == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderDetailModel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id);
            var orderDetailModel = (orderdetail.Data as OrderDetail);
            if (orderDetailModel != null)
            {
                OrderDetail = orderDetailModel;
                await _orderDetailBusiness.DeleteOrderDetail(orderDetailModel.OrderDetailId);
            }

            return RedirectToPage("./Index");
        }
    }
}
