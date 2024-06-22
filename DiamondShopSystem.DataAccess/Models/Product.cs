using System;
using System.Collections.Generic;

namespace DiamondShopSystem.DataAccess.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int DiamondSettingId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal Price { get; set; }

    public string Warranty { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Terms { get; set; }

    public int SideStoneId { get; set; }

    public int SideStoneAmount { get; set; }

    public int MainDiamondId { get; set; }

    public virtual DiamondSetting DiamondSetting { get; set; } = null!;

    public virtual MainDiamond MainDiamond { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual SideStone SideStone { get; set; } = null!;
}
