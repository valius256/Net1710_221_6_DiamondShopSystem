using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Models;

public partial class Net1710_221_6_DiamondShopSystemContext : DbContext
{
    public Net1710_221_6_DiamondShopSystemContext()
    {
    }

    public Net1710_221_6_DiamondShopSystemContext(DbContextOptions<Net1710_221_6_DiamondShopSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DiamondSetting> DiamondSettings { get; set; }

    public virtual DbSet<MainDiamond> MainDiamonds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SideStone> SideStones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=Net1710_221_6_DiamondShopSystem;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Birthday)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName).HasMaxLength(60);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiamondSetting>(entity =>
        {
            entity.Property(e => e.DiamondSettingId).HasColumnName("DiamondSettingID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.DiamondSettingMaterial).HasMaxLength(100);
            entity.Property(e => e.DiamondSettingSize).HasMaxLength(100);
            entity.Property(e => e.DiamondSettingWeight).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Image).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MainDiamond>(entity =>
        {
            entity.Property(e => e.MainDiamondId).HasColumnName("MainDiamondID");
            entity.Property(e => e.CaratWeight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Certificate).HasMaxLength(200);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryStatus).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(100);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Fee).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.OrderDetailNote).HasMaxLength(100);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.DiamondSettingId).HasColumnName("DiamondSettingID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MainDiamondId).HasColumnName("MainDiamondID");
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.SideStoneId).HasColumnName("SideStoneID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Terms).HasMaxLength(4000);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.Warranty).HasMaxLength(200);

            entity.HasOne(d => d.DiamondSetting).WithMany(p => p.Products)
                .HasForeignKey(d => d.DiamondSettingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_DiamondSettings1");

            entity.HasOne(d => d.MainDiamond).WithMany(p => p.Products)
                .HasForeignKey(d => d.MainDiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_MainDiamonds");

            entity.HasOne(d => d.SideStone).WithMany(p => p.Products)
                .HasForeignKey(d => d.SideStoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_SideStones1");
        });

        modelBuilder.Entity<SideStone>(entity =>
        {
            entity.Property(e => e.SideStoneId).HasColumnName("SideStoneID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.SideStoneCategory).HasMaxLength(50);
            entity.Property(e => e.SideStoneMaterial).HasMaxLength(50);
            entity.Property(e => e.SideStoneSize).HasMaxLength(50);
            entity.Property(e => e.SideStoneWeight).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
