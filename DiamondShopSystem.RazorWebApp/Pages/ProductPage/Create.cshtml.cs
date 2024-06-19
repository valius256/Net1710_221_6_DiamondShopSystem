using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public CreateModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness, IDiamondSettingBusiness diamondSettingBusiness, ISideStoneBusiness sideStoneBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
            _sideStoneBusiness = sideStoneBusiness;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var diamondSettings = (await _diamondSettingBusiness.GetAllDiamondSettings()).Data as List<DiamondSetting>;
            var mainDiamonds = (await _mainDiamondBusiness.GetAllMainDiamonds()).Data as List<MainDiamond>;
            var sideStones = (await _sideStoneBusiness.GetAllSideStones()).Data as List<SideStone>;

            ViewData["DiamondSettingId"] = new SelectList(diamondSettings, "DiamondSettingId", "Name");
            ViewData["MainDiamondId"] = new SelectList(mainDiamonds, "MainDiamondId", "MainDiamondType");
            ViewData["SideStoneId"] = new SelectList(sideStones, "SideStoneId", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productBusiness.CreateProduct(Product);
            return RedirectToPage("./Index");
        }
    }
}
