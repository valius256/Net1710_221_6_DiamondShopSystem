using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiamondShopSystem.Data.Models;

namespace DiamondShopSystem.RazorWebApp.Data
{
    public class DiamondShopSystemRazorWebAppContext : DbContext
    {
        public DiamondShopSystemRazorWebAppContext(DbContextOptions<DiamondShopSystemRazorWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}
