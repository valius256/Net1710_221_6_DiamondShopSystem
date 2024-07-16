using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public CreateModel(IOrderDetailBusiness orderDetail, IProductBusiness productBusiness, IOrderBusiness orderBusiness)
        {
            _orderDetailBusiness = orderDetail;
            _productBusiness = productBusiness;
            _orderBusiness = orderBusiness;
        }



        public async Task<IActionResult> OnGetAsync()
        {
            var orderList = (await _orderBusiness.GetAllOrder());
            var productList = (await _productBusiness.GetAllProducts());

            var orderListModel = (orderList.Data as List<Order>);
            var productListModel = productList.Data as List<Product>;
            ViewData["OrderId"] = new SelectList(orderListModel, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(productListModel, "ProductId", "ProductId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            await _orderDetailBusiness.CreateOrderDetail(OrderDetail);
            return RedirectToPage("./Index");
        }
    }
}
