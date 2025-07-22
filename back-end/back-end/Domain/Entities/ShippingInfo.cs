using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class ShippingInfo
{
    public int ShippingInfoId { get; set; }

    public int? OrderId { get; set; }

    public string? RecipientName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Order? Order { get; set; }
}
