﻿using System;
using System.Collections.Generic;

namespace DiamondShopSystem.DataAccess.Models;

public partial class MainDiamond
{
    public int MainDiamondId { get; set; }

    public int MainDiamondType { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Certificate { get; set; } = null!;

    public int Origin { get; set; }

    public int Size { get; set; }

    public decimal CaratWeight { get; set; }

    public int Color { get; set; }

    public int Clarity { get; set; }

    public int Cut { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
