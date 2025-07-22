using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class VwProductVariant
{
    public int VariantId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductNameEn { get; set; }

    public string? CategoryCode { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryNameEn { get; set; }

    public string? Description { get; set; }

    public int? ProductVersion { get; set; }

    public decimal? BasePrice { get; set; }

    public double? Rating { get; set; }

    public bool? ProductIsActive { get; set; }

    public string? ColorCode { get; set; }

    public string? Storages { get; set; }

    public decimal? Price { get; set; }

    public double? Discount { get; set; }

    public double? NewPrice { get; set; }

    public int VariantVersion { get; set; }

    public bool? IsActive { get; set; }

    public int? Stock { get; set; }

    public string? ImageUrls { get; set; }
}
