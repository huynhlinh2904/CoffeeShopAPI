using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class Order
{
    public Guid OrderId { get; set; }

    public string? OderName { get; set; }

    public int? Number { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? SizeId { get; set; }

    public int? TotalPrice { get; set; }

    public int? TableNumber { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
