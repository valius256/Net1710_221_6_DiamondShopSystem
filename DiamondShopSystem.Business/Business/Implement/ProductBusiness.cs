using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Common;
using DiamondShopSystem.Data.DAO;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.Business.Business.Implement
{

    public class ProductBusiness : IProductBusiness
    {
        private readonly ProductDAO _productDAO;

        public ProductBusiness()
        {
            _productDAO = new ProductDAO();
        }

        public async Task<IBusinessResult> CreateProduct(Product product)
        {
            try
            {
                int result = await _productDAO.CreateAsync(product);
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
        public async Task<IBusinessResult> DeleteProduct(int id)
        {
            try
            {
                var currency = await _productDAO.GetByIdAsync(id);
                if (currency != null)
                {
                    var result = await _productDAO.RemoveAsync(currency);
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

        public async Task<IBusinessResult> GetAllProducts()
        {
            var products = await _productDAO.GetAllAsync();
            if (products is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, products);
            }
        }

        public async Task<IBusinessResult> GetByIdAsync(int id)
        {
            var product = await _productDAO.GetByIdAsync(id);
            if (product is null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, product);
            }
        }

        public async Task<IBusinessResult> UpdateProduct(Product product)
        {
            try
            {
                int result = await _productDAO.UpdateAsync(product);
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
    }
}
