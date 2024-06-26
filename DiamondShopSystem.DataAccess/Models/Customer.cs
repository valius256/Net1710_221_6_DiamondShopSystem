using System;
using System.Collections.Generic;

namespace DiamondShopSystem.DataAccess.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Email { get; set; } = null!;

    public int Gender { get; set; }

    public string Birthday { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
