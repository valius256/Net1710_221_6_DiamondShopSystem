using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.DiamondSettingPage
{
    public class DiamondSettingModel : PageModel
    {
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        public DiamondSettingModel(IDiamondSettingBusiness diamondSettingBusiness)
        {
            _diamondSettingBusiness = diamondSettingBusiness;
        }
        public IEnumerable<DiamondSetting> DiamondSettings { get; set; } = new List<DiamondSetting>();

        public async Task OnGetAsync()
        {
            var result = await _diamondSettingBusiness.GetAllDiamondSettings();
            DiamondSettings = result.Data != null ? (List<DiamondSetting>)result.Data : new List<DiamondSetting>();

        }

        public void OnPost()
        {

        }
    }
}
