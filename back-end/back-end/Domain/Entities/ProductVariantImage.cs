using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class ProductVariantImage
{
    public int ImageId { get; set; }

    public int? VariantId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ProductVariant? Variant { get; set; }
}
