using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class Size
{
    public Guid SizeId { get; set; }

    public string? Size1 { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
