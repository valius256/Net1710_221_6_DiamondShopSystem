using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class OrderDetailBusiness : IOrderDetailBusiness
    {
        //private readonly OrderDAO _DAO;
        private readonly UnitOfWork _unitOfWork;

        public OrderDetailBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAllOrderDetail()
        {
            try
            {
                var orders = await _unitOfWork.OrderDetailRepository.GetAllAsync();
                if (orders == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.FAIL_READ_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orders);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(-4, e.Message.ToString());
            }
        }

        public async Task<IBusinessResult> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id);
                if (orderDetail == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.FAIL_READ_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderDetail);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                int result = await _unitOfWork.OrderDetailRepository.CreateAsync(orderDetail);
                if (result < 0)
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                }
            }
            catch (Exception e)

            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message.ToString());
            }
        }

        public async Task<IBusinessResult> UpdateOrderDetail(OrderDetail order)
        {
            try
            {
                int result = await _unitOfWork.OrderDetailRepository.UpdateAsync(order);
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
                return new BusinessResult(-4, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteOrderDetail(int id)
        {
            try
            {
                var order = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id);
                if (order != null)
                {
                    var result = await _unitOfWork.OrderDetailRepository.RemoveAsync(order);
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
                return new BusinessResult(-4, ex.ToString());
            }
        }
    }
}