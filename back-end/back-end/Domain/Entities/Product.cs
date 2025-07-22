using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? CategoryCode { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductNameEn { get; set; }

    public string? Description { get; set; }

    public int ProductVersion { get; set; }

    public decimal? BasePrice { get; set; }

    public double? Rating { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? CategoryCodeNavigation { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductVariantTracking> ProductVariantTrackings { get; set; } = new List<ProductVariantTracking>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
