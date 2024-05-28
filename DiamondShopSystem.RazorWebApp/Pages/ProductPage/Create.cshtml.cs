using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly ProductBusiness _productBusiness;
        public CreateModel(ProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [BindProperty]
        public Product? Product { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Product == null)
            {
                return Page();
            }

            var result = await _productBusiness.CreateProduct(Product);
            Debug.WriteLine(result);
            return RedirectToPage("./Index");
        }
    }
}
