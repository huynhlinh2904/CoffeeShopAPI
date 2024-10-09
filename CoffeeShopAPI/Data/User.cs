using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class User
{
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
