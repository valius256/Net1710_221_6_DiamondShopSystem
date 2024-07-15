using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DiamondShopSystem.RazorWebApp.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly ICustomerBusiness _customerBusiness;

        public CreateModel(IOrderBusiness orderBusiness, ICustomerBusiness customerBusiness)
        {
            _orderBusiness = orderBusiness;
            _customerBusiness = customerBusiness;
        }



        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CustomerId"] = new SelectList((await _customerBusiness.GetAllCustomerAsync()).Data as List<Customer>, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            await _orderBusiness.CreateOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}