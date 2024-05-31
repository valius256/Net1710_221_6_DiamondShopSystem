using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace DiamondShopSystem.RazorWebApp.Pages.MainDiamondPage
{
    public class CreateModel : PageModel
    {
        private readonly IMainDiamondBusiness _mainDiamondBusiness;

        public CreateModel(IMainDiamondBusiness mainDiamondBusiness)
        {
            _mainDiamondBusiness = mainDiamondBusiness;
        }

        [BindProperty]
        public MainDiamond MainDiamond { get; set; }

        public void OnGet()
        {
            // Initialize any necessary data for the page
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || MainDiamond == null)
            {
                return Page();
            }

            MainDiamond.CreateAt = DateTime.Now; // Set CreateAt
            MainDiamond.UpdateAt = DateTime.Now; // Set UpdateAt

            var result = await _mainDiamondBusiness.CreateMainDiamond(MainDiamond);
            if (result.Status == 1) // Check the Status property to confirm success
            {
                return RedirectToPage("./Index");
            }

            // Handle errors, e.g., add model errors
            ModelState.AddModelError(string.Empty, result.Message);
            return Page();
        }
    }
}
