using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface ISideStoneBusiness
    {
        Task<IBusinessResult> GetAllSideStones();
        Task<IBusinessResult> GetByIdAsync(int id);
        Task<IBusinessResult> CreateSideStone(SideStone sideStone);
        Task<IBusinessResult> UpdateSideStone(SideStone sideStone);
        Task<IBusinessResult> DeleteSideStone(int id);
    }
}
