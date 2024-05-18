﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DiamondShopSystem.Data.Models;

public partial class DiamondSetting
{
    public int DiamondSettingId { get; set; }

    public string Name { get; set; }

    public int DiamondSettingCategory { get; set; }

    public string Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal Price { get; set; }

    public string Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}