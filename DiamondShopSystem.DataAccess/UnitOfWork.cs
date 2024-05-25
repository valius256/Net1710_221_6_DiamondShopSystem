using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Repository;

namespace DiamondShopSystem.DataAccess
{
    public class UnitOfWork
    {
        private Net1710_221_6_DiamondShopSystemContext _unitOfWorkContext;

        private ProductRepository _product;

        public UnitOfWork()
        {

        }

        public ProductRepository ProductRepository
        {
            get
            {
                return _product ?? new Repository.ProductRepository();
            }
        }
    }
}
