using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Data;

public partial class History
{
    public Guid HistoryId { get; set; }

    public Guid? OderId { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Order? Oder { get; set; }

    public virtual User? PhoneNumberNavigation { get; set; }
}
