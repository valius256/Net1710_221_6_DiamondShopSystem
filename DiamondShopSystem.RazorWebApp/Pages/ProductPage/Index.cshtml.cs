using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public IndexModel(IProductBusiness productBusiness, IMainDiamondBusiness mainDiamondBusiness, IDiamondSettingBusiness diamondSettingBusiness, ISideStoneBusiness sideStoneBusiness)
        {
            _productBusiness = productBusiness;
            _mainDiamondBusiness = mainDiamondBusiness;
            _diamondSettingBusiness = diamondSettingBusiness;
            _sideStoneBusiness = sideStoneBusiness;
        }

        public IList<Product> Product { get; set; } = default!;
        public IList<SideStone> SideStones { get; set; } = default!;
        public IList<DiamondSetting> DiamondSettings { get; set; } = default!;
        public IList<MainDiamond> MainDiamonds { get; set; } = default!;

        public QueryProductDto queryProductDto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = (await _productBusiness.GetAllProducts()).Data as List<Product> ?? new List<Product>();
        }
    }
}
