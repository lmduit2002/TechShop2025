using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class ProductVariantTracking
{
    public long Id { get; set; }

    public int? VariantId { get; set; }

    public int? VariantVerion { get; set; }

    public int? ProductId { get; set; }

    public string? Color { get; set; }

    public string? Storage { get; set; }

    public decimal? Price { get; set; }

    public int? Discount { get; set; }

    public decimal? NewPrice { get; set; }

    public int? Stock { get; set; }

    public virtual Product? Product { get; set; }
}
