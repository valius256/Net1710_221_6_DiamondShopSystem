using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
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
        public EditModel(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }



        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderBusiness.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            var res = (await _customerBusiness.GetAllCustomerAsync()).Data;
            ViewData["CustomerId"] = new SelectList((await _customerBusiness.GetAllCustomerAsync()).Data as List<Customer>, "CustomerId", "CustomerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Order).State = EntityState.Modified;

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
            var rs =  _orderBusiness.GetOrderById(id).Result as Order;
            return rs != null;
        }
    }
}
