using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class EditModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly ICustomerBusiness _customerBusiness;
        public EditModel(IOrderBusiness orderBusiness, ICustomerBusiness customerBusiness)
        {
            _orderBusiness = orderBusiness;
            _customerBusiness = customerBusiness;
        }



        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var orderResult = await _orderBusiness.GetOrderById(id);
            var order = orderResult.Data as Order;

            if (order == null)
            {
                return NotFound();
            }

            Order = order;

            var customerResult = await _customerBusiness.GetCustomerByIdAsync(order.CustomerId);
            var customer = customerResult.Data as Customer;

            if (customer == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(new List<Customer> { customer }, "CustomerId", "CustomerId");

            return Page();
        }




        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _orderBusiness.UpdateOrder(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
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

        private bool OrderExists(int id)
        {
            var rs = _orderBusiness.GetOrderById(id).Result as Order;
            return rs != null;
        }
    }
}