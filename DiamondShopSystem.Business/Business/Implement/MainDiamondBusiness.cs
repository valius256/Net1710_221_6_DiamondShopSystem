

using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class MainDiamondBusiness : IMainDiamondBusiness
    {
        //private readonly ProductDAO _productDAO;
        private readonly UnitOfWork _unitOfWork;
        public MainDiamondBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> CreateMainDiamond(MainDiamond mainDiamond)
        {
            try
            {
                int result = await _unitOfWork.MainDiamondRepository.CreateAsync(mainDiamond);
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

        public async Task<IBusinessResult> DeleteMainDiamond(int id)
        {
            try
            {
                var currency = await _unitOfWork.MainDiamondRepository.GetByIdAsync(id);
                if (currency != null)
                {
                    var result = await _unitOfWork.MainDiamondRepository.RemoveAsync(currency);
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

        public async Task<IBusinessResult> GetAllMainDiamonds()
        {
            var mainDiamonds = await _unitOfWork.MainDiamondRepository.GetAllAsync();
            if (mainDiamonds is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, mainDiamonds);
            }
        }

        public async Task<IBusinessResult> GetByIdAsync(int id)
        {
            var mainDiamond = await _unitOfWork.MainDiamondRepository.GetByIdAsync(id);
            if (mainDiamond is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, mainDiamond);
            }
        }

        public async Task<IBusinessResult> UpdateMainDiamond(MainDiamond mainDiamond)
        {
            try
            {
                int result = await _unitOfWork.MainDiamondRepository.UpdateAsync(mainDiamond);
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
