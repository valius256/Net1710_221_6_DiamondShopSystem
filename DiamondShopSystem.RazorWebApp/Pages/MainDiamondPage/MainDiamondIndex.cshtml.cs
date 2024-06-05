using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.MainDiamondPage
{
    public class MainDiamondModel : PageModel
    {
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        public MainDiamondModel(IMainDiamondBusiness mainDiamondBusiness)
        {
            _mainDiamondBusiness = mainDiamondBusiness;
        }
        public IEnumerable<MainDiamond> MainDiamonds { get; set; } = new List<MainDiamond>();

        public async Task OnGetAsync()
        {
            var result = await _mainDiamondBusiness.GetAllMainDiamonds();
            MainDiamonds = result.Data != null ? (List<MainDiamond>)result.Data : new List<MainDiamond>();

        }

        public void OnPost()
        {

        }
    }
}
