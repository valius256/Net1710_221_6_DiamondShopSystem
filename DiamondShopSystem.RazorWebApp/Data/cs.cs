using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.DataAccess.Models;

namespace DiamondShopSystem.DataAccess.Models.Net1710_221_6_DiamondShopSystemContext
{
    public class cs : DbContext
    {
        public cs (DbContextOptions<cs> options)
            : base(options)
        {
        }

        public DbSet<DiamondShopSystem.DataAccess.Models.SideStone> SideStone { get; set; } = default!;
        public DbSet<DiamondShopSystem.DataAccess.Models.Customer> Customer { get; set; } = default!;
        public DbSet<DiamondShopSystem.DataAccess.Models.DiamondSetting> DiamondSetting { get; set; } = default!;
        public DbSet<DiamondShopSystem.DataAccess.Models.MainDiamond> MainDiamond { get; set; } = default!;
        public DbSet<DiamondShopSystem.DataAccess.Models.Order> Order { get; set; } = default!;
        public DbSet<DiamondShopSystem.DataAccess.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
