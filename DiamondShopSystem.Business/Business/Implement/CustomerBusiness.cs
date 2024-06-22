using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.ViewModels;
using DiamondShopSystem.Common;
using DiamondShopSystem.DataAccess.Models;
using DiamondShopSystem.DataAccess;

namespace DiamondShopSystem.Business.Business.Implement
{
    public class CustomerBusiness : ICustomerBusiness
    {
        //private readonly CustomerDAO _unitOfWork.CustomerRepository;
        private readonly UnitOfWork _unitOfWork;
        public CustomerBusiness()
        {
            //_unitOfWork.CustomerRepository = new CustomerDAO();
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAllCustomerAsync()

        {
            try
            {
                //var customers = await _unitOfWork.CustomerRepository.GetAllAsync();

                var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
                if (customers == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.FAIL_READ_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customers);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.FAIL_READ_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customer);
                }
            }
            catch (Exception e)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }

        public async Task<IBusinessResult> CreateCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _unitOfWork.CustomerRepository.CreateAsync(customer);
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

        public async Task<IBusinessResult> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _unitOfWork.CustomerRepository.UpdateAsync(customer);
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

        public async Task<IBusinessResult> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _unitOfWork.CustomerRepository.RemoveAsync(customer);
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