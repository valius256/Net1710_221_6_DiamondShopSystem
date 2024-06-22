using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public EditModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness, IDiamondSettingBusiness diamondSettingBusiness, ISideStoneBusiness sideStoneBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
            _sideStoneBusiness = sideStoneBusiness;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productBusiness.GetByIdAsync((int)id);
            if (product.Data == null)
            {
                return NotFound();
            }
            Product = product.Data as Product ?? new Product();
            var diamondSettings = (await _diamondSettingBusiness.GetAllDiamondSettings()).Data as List<DiamondSetting>;
            var mainDiamonds = (await _mainDiamondBusiness.GetAllMainDiamonds()).Data as List<MainDiamond>;
            var sideStones = (await _sideStoneBusiness.GetAllSideStones()).Data as List<SideStone>;

            ViewData["DiamondSettingId"] = new SelectList(diamondSettings, "DiamondSettingId", "DiamondSettingId");
            ViewData["MainDiamondId"] = new SelectList(mainDiamonds, "MainDiamondId", "MainDiamondId");
            ViewData["SideStoneId"] = new SelectList(sideStones, "SideStoneId", "SideStoneId");
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

            try
            {
                await _productBusiness.UpdateProduct(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(Product.ProductId))
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

        private async Task<bool> ProductExists(int id)
        {
            var product = await _productBusiness.GetByIdAsync(id);
            return product.Data != null;
        }
    }
}
