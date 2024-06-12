using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.RazorWebApp.DataAccess
{
    public class DiamondShopSystemRazorWebAppContext : DbContext
    {
        public DiamondShopSystemRazorWebAppContext (DbContextOptions<DiamondShopSystemRazorWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<DiamondShopSystem.Data.Models.Product> Product { get; set; } = default!;
    }
}
