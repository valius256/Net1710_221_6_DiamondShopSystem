using System;
using System.Collections.Generic;

namespace DiamondShopSystem.DataAccess.Models;

public partial class DiamondSetting
{
    public int DiamondSettingId { get; set; }

    public string Name { get; set; } = null!;

    public int DiamondSettingCategory { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public string? DiamondSettingMaterial { get; set; }

    public decimal? DiamondSettingWeight { get; set; }

    public string? DiamondSettingSize { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
