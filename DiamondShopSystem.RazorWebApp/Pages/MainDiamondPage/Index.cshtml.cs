using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.MainDiamondPage
{
    public class IndexModel : PageModel
    {
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        public IndexModel(IMainDiamondBusiness mainDiamondBusiness)
        {
            _mainDiamondBusiness = mainDiamondBusiness;
        }

        public IList<MainDiamond> MainDiamond { get; set; } = default!;

        public QueryMainDiamondDto queryMainDiamondDto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            MainDiamond = (await _mainDiamondBusiness.GetAllMainDiamonds()).Data as List<MainDiamond> ?? new List<MainDiamond>();
        }
    }
}
