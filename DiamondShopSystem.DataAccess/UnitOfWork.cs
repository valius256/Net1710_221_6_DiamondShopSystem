using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Repository;

namespace DiamondShopSystem.DataAccess
{
    public class UnitOfWork
    {
        private Net1710_221_6_DiamondShopSystemContext _unitOfWorkContext;

        private ProductRepository _product;
        private CustomerRepository _customer;
        private MainDiamondRepository _mainDiamond;
        private SideStoneRepository _sideStone;
        private DiamondSettingRepository _diamondSetting;

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
        public MainDiamondRepository MainDiamondRepository
        {
            get
            {
                return _mainDiamond ??= new MainDiamondRepository();
            }
        }
        public SideStoneRepository SideStoneRepository
        {
            get
            {
                return _sideStone ??= new SideStoneRepository();
            }
        }
        public DiamondSettingRepository DiamondSettingRepository
        {
            get
            {
                return _diamondSetting ??= new DiamondSettingRepository();
            }
        }
    }
}
