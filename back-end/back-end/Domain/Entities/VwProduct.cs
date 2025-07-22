using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class VwProduct
{
    public int ProductId { get; set; }

    public string? CategoryCode { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryNameEn { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductNameEn { get; set; }

    public string? Description { get; set; }

    public int ProductVersion { get; set; }

    public decimal? BasePrice { get; set; }

    public double? Rating { get; set; }

    public string? ImageUrls { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
