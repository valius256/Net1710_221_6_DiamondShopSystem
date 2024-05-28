using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Interfaces
{
    public interface IDiamondSettingBusiness
    {
        Task<IBusinessResult> GetAllDiamondSettings();
        Task<IBusinessResult> GetByIdAsync(int id);
        Task<IBusinessResult> CreateDiamondSetting(DiamondSetting diamondSetting);
        Task<IBusinessResult> UpdateDiamondSetting(DiamondSetting diamondSetting);
        Task<IBusinessResult> DeleteDiamondSetting(int id);
    }
}
