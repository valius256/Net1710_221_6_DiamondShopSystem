using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondShopSystem.RazorWebApp.Pages.SideStonePage
{
    public class IndexModel : PageModel
    {
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public IndexModel(ISideStoneBusiness sideStoneBusiness)
        {
            _sideStoneBusiness = sideStoneBusiness;
        }

        public IList<SideStone> SideStone { get; set; } = default!;

        public QuerySideStoneDto querySideStoneDto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            SideStone = (await _sideStoneBusiness.GetAllSideStones()).Data as List<SideStone> ?? new List<SideStone>();
        }
    }
}
