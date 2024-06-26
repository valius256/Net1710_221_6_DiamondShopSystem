using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Common.Dtos;
using DiamondShopSystem.DataAccess.Models;
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

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 0;
        public int TotalPage { get; set; } = 1;
        public QueryProductDto queryProductDto { get; set; } = default!;

        public async Task OnGetAsync(QueryProductDto queryProductDto)
        {
            Product = (await _productBusiness.GetProductQueried(queryProductDto)).Data as List<Product> ?? new List<Product>();
        }

        public void OnPost()
        {
            RedirectToAction("Index", queryProductDto);
        }
    }
}
