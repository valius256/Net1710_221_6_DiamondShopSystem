using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IMainDiamondBusiness
    {
        Task<IBusinessResult> GetAllMainDiamonds();
        Task<IBusinessResult> GetByIdAsync(int id);
        Task<IBusinessResult> CreateMainDiamond(MainDiamond mainDiamond);
        Task<IBusinessResult> UpdateMainDiamond(MainDiamond mainDiamond);
        Task<IBusinessResult> DeleteMainDiamond(int id);
    }
}
