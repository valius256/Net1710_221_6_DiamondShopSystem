using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.DiamondSettingPage
{
    public class CreateModel : PageModel
    {
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;

        public CreateModel(IDiamondSettingBusiness diamondSettingBusiness)
        {
            _diamondSettingBusiness = diamondSettingBusiness;
        }

        [BindProperty]
        public DiamondSetting DiamondSetting { get; set; }

        public void OnGet()
        {
            // Initialize any necessary data for the page
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || DiamondSetting == null)
            {
                return Page();
            }

            DiamondSetting.CreateAt = DateTime.Now; // Set CreateAt
            DiamondSetting.UpdateAt = DateTime.Now; // Set UpdateAt

            var result = await _diamondSettingBusiness.CreateDiamondSetting(DiamondSetting);
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
