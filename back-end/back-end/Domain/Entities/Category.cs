using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class Category
{
    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string? CategoryNameEn { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ProductTracking> ProductTrackings { get; set; } = new List<ProductTracking>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SysStorageGroup> SysStorageGroups { get; set; } = new List<SysStorageGroup>();
}
