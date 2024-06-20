using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class DeleteModel : PageModel
    {
        private readonly OrderDetailBusiness _orderDetailBusiness;

        public DeleteModel(OrderDetailBusiness orderDetailBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id) as OrderDetail;
        
            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id) as OrderDetail;
            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _orderDetailBusiness.DeleteOrderDetail(orderdetail.OrderDetailId);
            }

            return RedirectToPage("./Index");
        }
    }
}
