using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly IOrderDetailBusiness _orderDetailBusiness;

        public CreateModel(IOrderBusiness orderBusiness, IOrderDetailBusiness orderDetailBusiness)
        {
            _orderBusiness = orderBusiness;
            _orderDetailBusiness = orderDetailBusiness;
        }

        [BindProperty]
        public Data.Models.Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public async Task OnGetAsync()
        {
            var orderDetail = await _orderDetailBusiness.GetAllOrderDetail();
            OrderDetails = orderDetail.Data != null ? (List<OrderDetail>)orderDetail.Data : new List<OrderDetail>();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Order == null)
            {
                return Page();
            }

            var result = await _orderBusiness.CreateOrder(Order);
            Debug.WriteLine(result);
            return RedirectToPage("./Index");
        }
    }
}
