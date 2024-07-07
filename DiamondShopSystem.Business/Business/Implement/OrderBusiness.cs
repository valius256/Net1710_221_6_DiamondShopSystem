using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Dtos;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.DataAccess;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class OrderBusiness : IOrderBusiness
    {
        //private readonly OrderDAO _DAO;
        private readonly UnitOfWork _unitOfWork;

        public OrderBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAllOrder()
        {
            try
            {
                var orders = await _unitOfWork.OrderRepository.GetAllAsync();
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

        public async Task<IBusinessResult> Save(Order order)
        {
            try
            {
                var result = await _unitOfWork.OrderRepository.SaveAsync(order);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(-4, e.Message.ToString());
            }
        }

        public async Task<IBusinessResult> GetOrderById(int id)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
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

        public async Task<IBusinessResult> CreateOrder(Order order)
        {
            try
            {
                int result = await _unitOfWork.OrderRepository.CreateAsync(order);
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

        public async Task<IBusinessResult> UpdateOrder(Order order)
        {
            try
            {
                int result = await _unitOfWork.OrderRepository.UpdateAsync(order);

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

        public async Task<IBusinessResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
                if (order != null)
                {
                    var result = await _unitOfWork.OrderRepository.RemoveAsync(order);
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

        public async Task<IBusinessResult> GetQueriedOrder(QueryOrderDto queryOrderDto)
        {
            var orders = await _unitOfWork.OrderRepository.GetQueriedOrder(queryOrderDto);
            if (orders is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orders);
            }
        }

        public async Task<IBusinessResult> OrderExist(int id)
        {
            var ordersList = await _unitOfWork.OrderRepository.GetAllAsync();
            var order = ordersList.FirstOrDefault(ld => ld.OrderId == id);
            if (order is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, order);
            }
        }
    }
}