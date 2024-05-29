using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class DiamondSettingBusiness : IDiamondSettingBusiness
    {
        //private readonly ProductDAO _productDAO;
        private readonly UnitOfWork _unitOfWork;
        public DiamondSettingBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> CreateDiamondSetting(DiamondSetting diamondSetting)
        {
            try
            {
                int result = await _unitOfWork.DiamondSettingRepository.CreateAsync(diamondSetting);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteDiamondSetting(int id)
        {
            try
            {
                var diamondSetting = await _unitOfWork.DiamondSettingRepository.GetByIdAsync(id);
                if (diamondSetting != null)
                {
                    var result = await _unitOfWork.DiamondSettingRepository.RemoveAsync(diamondSetting);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetAllDiamondSettings()
        {
            var diamondSettings = await _unitOfWork.DiamondSettingRepository.GetAllAsync();
            if (diamondSettings is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, diamondSettings);
            }
        }

        public async Task<IBusinessResult> GetByIdAsync(int id)
        {
            var diamondSetting = await _unitOfWork.DiamondSettingRepository.GetByIdAsync(id);
            if (diamondSetting is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, diamondSetting);
            }
        }

        public async Task<IBusinessResult> UpdateDiamondSetting(DiamondSetting diamondSetting)
        {
            try
            {
                int result = await _unitOfWork.DiamondSettingRepository.UpdateAsync(diamondSetting);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
    }
}
