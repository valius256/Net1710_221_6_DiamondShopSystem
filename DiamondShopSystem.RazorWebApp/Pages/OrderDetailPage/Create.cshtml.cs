using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;
        private readonly  IProductBusiness _productBusiness;
        public CreateModel(IOrderDetailBusiness orderDetail, IProductBusiness productBusiness)
        {
            _orderDetailBusiness = orderDetail;
            _productBusiness = productBusiness;
        }

      
        
        public async Task<IActionResult> OnGetAsync()
        {
            var orderList = (await _orderDetailBusiness.GetAllOrderDetail()).Data as List<OrderDetail>;
            var productList =  (await _orderDetailBusiness.GetAllOrderDetail()).Data as List<Product>;
            
            ViewData["OrderId"] = new SelectList(orderList, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(productList, "ProductId", "ProductId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             await _orderDetailBusiness.CreateOrderDetail(OrderDetail);
            return RedirectToPage("./Index");
        }
    }
}
