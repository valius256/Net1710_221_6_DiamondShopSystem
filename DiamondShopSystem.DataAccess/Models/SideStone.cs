using System;
using System.Collections.Generic;

namespace DiamondShopSystem.DataAccess.Models;

public partial class SideStone
{
    public int SideStoneId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal? SideStoneWeight { get; set; }

    public string? SideStoneSize { get; set; }

    public string? SideStoneMaterial { get; set; }

    public string? SideStoneCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
