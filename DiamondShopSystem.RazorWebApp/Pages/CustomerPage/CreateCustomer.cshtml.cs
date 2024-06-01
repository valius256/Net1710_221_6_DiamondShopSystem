using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace DiamondShopSystem.RazorWebApp.Pages.CustomerPage
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CreateModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {
            // Initialize any necessary data for the page
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Customer == null)
            {
                return Page();
            }

            Customer.CreateAt = DateTime.Now; // Set CreateAt
            Customer.UpdateAt = DateTime.Now; // Set UpdateAt

            var result = await _customerBusiness.CreateCustomerAsync(Customer);
            if (result.Success) // Check the Success property
            {
                return RedirectToPage("./Index");
            }

            // Handle errors, e.g., add model errors
            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return Page();
        }
    }
}
