using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class ProductTracking
{
    public long Id { get; set; }

    public int? ProductId { get; set; }

    public int? ProductVersion { get; set; }

    public string? CategoryCode { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductNameEn { get; set; }

    public string? Description { get; set; }

    public decimal? BasePrice { get; set; }

    public double? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? CategoryCodeNavigation { get; set; }
}
