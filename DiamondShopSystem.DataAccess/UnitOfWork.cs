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
        private OrderRepository _order;
        private OrderDetailRepository _orderDetail;


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
        public OrderRepository OrderRepository
        {
            get
            {
                return _order ??= new Repository.OrderRepository();
            }
        }

        public OrderDetailRepository OrderDetailRepository
        {
            get
            {
                return _orderDetail ??= new OrderDetailRepository();
            }
        }

        ////TO-DO CODE HERE/////////////////

        #region Set transaction isolation levels

        /*
        Read Uncommitted: The lowest level of isolation, allows transactions to read uncommitted data from other transactions. This can lead to dirty reads and other issues.

        Read Committed: Transactions can only read data that has been committed by other transactions. This level avoids dirty reads but can still experience other isolation problems.

        Repeatable Read: Transactions can only read data that was committed before their execution, and all reads are repeatable. This prevents dirty reads and non-repeatable reads, but may still experience phantom reads.

        Serializable: The highest level of isolation, ensuring that transactions are completely isolated from one another. This can lead to increased lock contention, potentially hurting performance.

        Snapshot: This isolation level uses row versioning to avoid locks, providing consistency without impeding concurrency. 
         */

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = _unitOfWorkContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = await _unitOfWorkContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        #endregion
    }
}
