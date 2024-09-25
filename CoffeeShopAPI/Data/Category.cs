using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
