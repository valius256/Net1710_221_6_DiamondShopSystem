using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class SideStoneBusiness : ISideStoneBusiness
    {
        //private readonly ProductDAO _productDAO;
        private readonly UnitOfWork _unitOfWork;
        public SideStoneBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> CreateSideStone(SideStone sideStone)
        {
            try
            {
                int result = await _unitOfWork.SideStoneRepository.CreateAsync(sideStone);
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

        public async Task<IBusinessResult> DeleteSideStone(int id)
        {
            try
            {
                var sideStone = await _unitOfWork.SideStoneRepository.GetByIdAsync(id);
                if (sideStone != null)
                {
                    var result = await _unitOfWork.SideStoneRepository.RemoveAsync(sideStone);
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

        public async Task<IBusinessResult> GetAllSideStones()
        {
            var sideStones = await _unitOfWork.SideStoneRepository.GetAllAsync();
            if (sideStones is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, sideStones);
            }
        }

        public async Task<IBusinessResult> GetByIdAsync(int id)
        {
            var sideStone = await _unitOfWork.SideStoneRepository.GetByIdAsync(id);
            if (sideStone is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, sideStone);
            }
        }

        public async Task<IBusinessResult> UpdateSideStone(SideStone sideStone)
        {
            try
            {
                int result = await _unitOfWork.SideStoneRepository.UpdateAsync(sideStone);
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
