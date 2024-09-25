using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public bool? BestSeller { get; set; }

    public bool? Status { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
