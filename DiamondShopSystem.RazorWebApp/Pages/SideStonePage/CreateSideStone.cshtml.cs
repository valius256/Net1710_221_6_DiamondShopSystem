using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.SideStonePage
{
    public class CreateModel : PageModel
    {
        private readonly ISideStoneBusiness _sideStoneBusiness;

        public CreateModel(ISideStoneBusiness sideStoneBusiness)
        {
            _sideStoneBusiness = sideStoneBusiness;
        }

        [BindProperty]
        public SideStone SideStone { get; set; }

        public void OnGet()
        {
            // Initialize any necessary data for the page
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || SideStone == null)
            {
                return Page();
            }

            SideStone.CreateAt = DateTime.Now; // Set CreateAt
            SideStone.UpdateAt = DateTime.Now; // Set UpdateAt

            var result = await _sideStoneBusiness.CreateSideStone(SideStone);
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
