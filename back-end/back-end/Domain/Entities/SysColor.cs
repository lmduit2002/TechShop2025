using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class SysColor
{
    public string ColorCode { get; set; } = null!;

    public string? ColorName { get; set; }

    public string? ColorName2 { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
