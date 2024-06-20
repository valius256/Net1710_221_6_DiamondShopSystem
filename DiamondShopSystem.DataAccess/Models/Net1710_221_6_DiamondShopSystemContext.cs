﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiamondShopSystem.Data.Models;

public partial class  Net1710_221_6_DiamondShopSystemContext : DbContext
{
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

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        Console.Write("appsettings: ", connectionString);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Birthday)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiamondSetting>(entity =>
        {
            entity.Property(e => e.DiamondSettingId)
                .ValueGeneratedNever()
                .HasColumnName("DiamondSettingID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Image).HasMaxLength(200);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MainDiamond>(entity =>
        {
            entity.Property(e => e.MainDiamondId)
                .ValueGeneratedNever()
                .HasColumnName("MainDiamondID");
            entity.Property(e => e.CaratWeight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Certificate)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryStatus)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
            entity.HasMany(d => d.OrderDetails).WithOne(p => p.Order)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Fee).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShipmentDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentTrackingNumber).HasMaxLength(10);
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

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
            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.DiamondSettingId).HasColumnName("DiamondSettingID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MainDiamondId).HasColumnName("MainDiamondID");
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.SideStoneId).HasColumnName("SideStoneID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Terms).HasMaxLength(4000);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.Warranty)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.DiamondSetting).WithMany(p => p.Products)
                .HasForeignKey(d => d.DiamondSettingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_DiamondSettings");

            entity.HasOne(d => d.MainDiamond).WithMany(p => p.Products)
                .HasForeignKey(d => d.MainDiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_MainDiamonds");

            entity.HasOne(d => d.SideStone).WithMany(p => p.Products)
                .HasForeignKey(d => d.SideStoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_SideStones");
        });

        modelBuilder.Entity<SideStone>(entity =>
        {
            entity.Property(e => e.SideStoneId)
                .ValueGeneratedNever()
                .HasColumnName("SideStoneID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Descriptoin).HasMaxLength(2000);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}