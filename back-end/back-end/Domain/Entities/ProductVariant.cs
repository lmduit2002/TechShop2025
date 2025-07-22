using System;
using System.Collections.Generic;

namespace back_end.Domain.Entities;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int? ProductId { get; set; }

    public string? ColorCode { get; set; }

    public string? Storages { get; set; }

    public decimal? Price { get; set; }

    public double? Discount { get; set; }

    public double? NewPrice { get; set; }

    public int VariantVersion { get; set; }

    public bool? IsActive { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual SysColor? ColorCodeNavigation { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductVariantImage> ProductVariantImages { get; set; } = new List<ProductVariantImage>();
}
