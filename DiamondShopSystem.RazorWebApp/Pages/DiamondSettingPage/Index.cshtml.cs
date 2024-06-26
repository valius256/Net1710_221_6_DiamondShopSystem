using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.DiamondSettingPage
{
    public class IndexModel : PageModel
    {
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        public IndexModel(IDiamondSettingBusiness diamondSettingBusiness)
        {
            _diamondSettingBusiness = diamondSettingBusiness;
        }

        public IList<DiamondSetting> DiamondSetting { get; set; } = default!;

        public QueryDiamondSettingDto queryDiamondSettingDto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            DiamondSetting = (await _diamondSettingBusiness.GetAllDiamondSettings()).Data as List<DiamondSetting> ?? new List<DiamondSetting>();
        }
    }
}
