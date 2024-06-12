using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;

        public CreateModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness,
            ISideStoneBusiness sideStoneBusiness, IDiamondSettingBusiness diamondSettingBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _sideStoneBusiness = sideStoneBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<MainDiamond> MainDiamonds { get; set; }
        public List<DiamondSetting> DiamondSettings { get; set; }
        public List<SideStone> SideStones { get; set; }

        public async Task OnGetAsync()
        {
            var mainDiamonds = await _mainDiamondBusiness.GetAllMainDiamonds();
            MainDiamonds = mainDiamonds.Data != null ? (List<MainDiamond>)mainDiamonds.Data : new List<MainDiamond>();
            var sideStones = await _sideStoneBusiness.GetAllSideStones();
            SideStones = sideStones.Data != null ? (List<SideStone>)sideStones.Data : new List<SideStone>();
            var diamondSettings = await _diamondSettingBusiness.GetAllDiamondSettings();
            DiamondSettings = diamondSettings.Data != null ? (List<DiamondSetting>)diamondSettings.Data : new List<DiamondSetting>();
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
