using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderDetailPage
{
    public class EditModel : PageModel
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;
        private readonly IOrderBusiness _orderBusiness;
        private readonly IProductBusiness _productBusiness;
        public EditModel(IOrderDetailBusiness orderDetailBusiness, IOrderBusiness orderBusiness, IProductBusiness productBusiness)
        {
            _orderDetailBusiness = orderDetailBusiness;
            _orderBusiness = orderBusiness;
            _productBusiness = productBusiness;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _orderDetailBusiness.GetOrderDetailById(id);
            var orderDetailModel = orderdetail.Data as OrderDetail;
            if (orderDetailModel == null)
            {
                return NotFound();
            }
            OrderDetail = orderDetailModel;
            var orderList = (await _orderBusiness.GetAllOrder()).Data as List<Order>;
            var productList = (await _productBusiness.GetAllProducts()).Data as List<Product>;


            ViewData["OrderId"] = new SelectList(orderList, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(productList, "ProductId", "ProductId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _orderDetailBusiness.UpdateOrderDetail(OrderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderDetailExists(OrderDetail.OrderDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> OrderDetailExists(int id)
        {
            var order = await _orderDetailBusiness.GetOrderDetailById(id);
            return order.Data != null;
        }
    }
}
