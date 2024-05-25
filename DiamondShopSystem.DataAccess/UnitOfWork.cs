using DiamondShopSystem.Data.Models;
using DiamondShopSystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShopSystem.DataAccess
{
    public class UnitOfWork
    {
        private Net1710_221_6_DiamondShopSystemContext _unitOfWorkContext;
        private CustomerRepository _customer;
        public UnitOfWork()
        {

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
