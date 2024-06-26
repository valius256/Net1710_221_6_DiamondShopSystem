using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.Data.Models;
using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Common.Dtos;

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
