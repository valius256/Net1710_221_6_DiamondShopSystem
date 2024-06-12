using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.SideStonePage
{
    public class SideStoneModel : PageModel
    {
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public SideStoneModel(ISideStoneBusiness sideStoneBusiness)
        {
            _sideStoneBusiness = sideStoneBusiness;
        }
        public IEnumerable<SideStone> SideStones { get; set; } = new List<SideStone>();

        public async Task OnGetAsync()
        {
            var result = await _sideStoneBusiness.GetAllSideStones();
            SideStones = result.Data != null ? (List<SideStone>)result.Data : new List<SideStone>();

        }

        public void OnPost()
        {

        }
    }
}
