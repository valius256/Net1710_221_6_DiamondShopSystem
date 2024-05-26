using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.Data.DAO;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Imp
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly OrderDAO _DAO;

        public OrderBusiness()
        {
            _DAO = new OrderDAO();
        }

        public async Task<IBusinessResult> GetAllOrderAsync()

        {
            try
            {
                var orders = await _DAO.GetAllAsync();
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
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _DAO.GetByIdAsync(id);
                if (order == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.FAIL_READ_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, order);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> CreateOrderAsync(Order order)
        {
            try
            {
                var result = await _DAO.CreateAsync(order);
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
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> UpdateOrderAsync(Order order)
        {
            try
            {
                var result = await _DAO.UpdateAsync(order);
                if (result < 0)
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG, result);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> DeleteOrderAsync(Order order)
        {
            try
            {
                var result = await _DAO.RemoveAsync(order);
                if (result)
                {
                    return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }
    }
}