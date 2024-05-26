using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Repository;

namespace DiamondShopSystem.DataAccess
{
    public class UnitOfWork
    {
        private Net1710_221_6_DiamondShopSystemContext _unitOfWorkContext;

        private ProductRepository _product;
        private CustomerRepository _customer;

        public UnitOfWork()
        {

        }


        public ProductRepository ProductRepository
        {
            get
            {
                return _product ?? new ProductRepository();
            }
        }
        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customer ??= new Repository.CustomerRepository();
            }
        }
    }
}
