using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using back_end.Domain.Entities;

namespace back_end.Infrastructure.Persistence;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductTracking> ProductTrackings { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<ProductVariantImage> ProductVariantImages { get; set; }

    public virtual DbSet<ProductVariantTracking> ProductVariantTrackings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShippingInfo> ShippingInfos { get; set; }

    public virtual DbSet<SysColor> SysColors { get; set; }

    public virtual DbSet<SysStorage> SysStorages { get; set; }

    public virtual DbSet<SysStorageGroup> SysStorageGroups { get; set; }

    public virtual DbSet<SysValueList> SysValueLists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserVoucher> UserVouchers { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VwProduct> VwProducts { get; set; }

    public virtual DbSet<VwProductVariant> VwProductVariants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L4BLRQD\\SQLEXPRESS;Database=TechShop2025;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD7B73C910425");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Carts__UserId__236943A5");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0A5A9B343E");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartItems__CartI__2739D489");

            entity.HasOne(d => d.Variant).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("FK__CartItems__Varia__282DF8C2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__Categori__371BA954FAEF45D3");

            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CategoryNameEn)
                .HasMaxLength(100)
                .HasColumnName("CategoryNameEN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAD57C8A6AB4");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favorites__UserI__2B0A656D");

            entity.HasOne(d => d.Variant).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("FK__Favorites__Varia__2BFE89A6");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF98097C2A");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserId__3864608B");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__Orders__VoucherI__3B40CD36");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED068128A75C3F");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__3E1D39E1");

            entity.HasOne(d => d.Variant).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("FK__OrderItem__Varia__3F115E1A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD585725BA");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductNameEn)
                .HasMaxLength(200)
                .HasColumnName("ProductNameEN");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryCode)
                .HasConstraintName("FK__Products__Catego__6FE99F9F");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ProductI__7516F70CCC11C39B");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductIm__Produ__114A936A");
        });

        modelBuilder.Entity<ProductTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductT__3214EC273D60CF61");

            entity.ToTable("ProductTracking");

            entity.HasIndex(e => new { e.ProductId, e.ProductVersion }, "UQ_ProductTracking_ProductId_ProductVersion").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductNameEn)
                .HasMaxLength(200)
                .HasColumnName("ProductNameEN");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.ProductTrackings)
                .HasForeignKey(d => d.CategoryCode)
                .HasConstraintName("FK__ProductTr__Categ__19DFD96B");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("PK__ProductV__0EA233847B81C0D1");

            entity.Property(e => e.ColorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NewPrice).HasComputedColumnSql("((1.0)*[Price]-[Price]*[Discount])", true);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Storages).HasMaxLength(200);

            entity.HasOne(d => d.ColorCodeNavigation).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ColorCode)
                .HasConstraintName("FK__ProductVa__Color__0C85DE4D");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductVa__Produ__0B91BA14");
        });

        modelBuilder.Entity<ProductVariantImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ProductV__7516F70C76CD1E22");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.Variant).WithMany(p => p.ProductVariantImages)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("FK__ProductVa__Varia__14270015");
        });

        modelBuilder.Entity<ProductVariantTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductV__3214EC27DA727F82");

            entity.ToTable("ProductVariantTracking");

            entity.HasIndex(e => new { e.VariantId, e.VariantVerion }, "UQ_ProductVariantTracking_VariantId_VariantVerion").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.NewPrice)
                .HasComputedColumnSql("([Price]-[Price]*[Discount])", true)
                .HasColumnType("decimal(30, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Storage).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariantTrackings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductVa__Produ__1EA48E88");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CEE5DA57D0");

            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__Product__47A6A41B");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserId__46B27FE2");
        });

        modelBuilder.Entity<ShippingInfo>(entity =>
        {
            entity.HasKey(e => e.ShippingInfoId).HasName("PK__Shipping__A72E5D754F63CEA9");

            entity.ToTable("ShippingInfo");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RecipientName).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.ShippingInfos)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__ShippingI__Order__42E1EEFE");
        });

        modelBuilder.Entity<SysColor>(entity =>
        {
            entity.HasKey(e => e.ColorCode).HasName("PK__SYS_Colo__56F16D95070FC2D2");

            entity.ToTable("SYS_Color");

            entity.Property(e => e.ColorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ColorName).HasMaxLength(100);
            entity.Property(e => e.ColorName2).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SysStorage>(entity =>
        {
            entity.HasKey(e => e.StorageCode).HasName("PK__SYS_Stor__AD8F8BC742BBD638");

            entity.ToTable("SYS_Storage");

            entity.Property(e => e.StorageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StorageGroupCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StorageName).HasMaxLength(100);
            entity.Property(e => e.StorageName2).HasMaxLength(100);

            entity.HasOne(d => d.StorageGroupCodeNavigation).WithMany(p => p.SysStorages)
                .HasForeignKey(d => d.StorageGroupCode)
                .HasConstraintName("FK__SYS_Stora__Stora__5AEE82B9");
        });

        modelBuilder.Entity<SysStorageGroup>(entity =>
        {
            entity.HasKey(e => e.StorageGroupCode).HasName("PK__SYS_Stor__B53499356B60D470");

            entity.ToTable("SYS_StorageGroup");

            entity.Property(e => e.StorageGroupCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StorageGroupName).HasMaxLength(100);
            entity.Property(e => e.StorageGroupName2).HasMaxLength(100);

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.SysStorageGroups)
                .HasForeignKey(d => d.CategoryCode)
                .HasConstraintName("FK__SYS_Stora__Categ__571DF1D5");
        });

        modelBuilder.Entity<SysValueList>(entity =>
        {
            entity.HasKey(e => new { e.ListName, e.Language });

            entity.ToTable("SYS_ValueList");

            entity.HasIndex(e => e.Language, "UQ__SYS_Valu__C3D5925036E66494").IsUnique();

            entity.Property(e => e.ListName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Language).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C1D1BE369");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E42AF32FF1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053447F3308E").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserVoucher>(entity =>
        {
            entity.HasKey(e => e.UserVoucherId).HasName("PK__UserVouc__8017D4993DAE1900");

            entity.Property(e => e.UsedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserVouch__UserI__4C6B5938");

            entity.HasOne(d => d.Voucher).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__UserVouch__Vouch__4D5F7D71");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Vouchers__3AEE7921EB2BFDF5");

            entity.HasIndex(e => e.Code, "UQ__Vouchers__A25C5AA7DEC9D2FD").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DiscountType).HasMaxLength(20);
            entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MinOrderAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<VwProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwProducts");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CategoryNameEn)
                .HasMaxLength(100)
                .HasColumnName("CategoryNameEN");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrls).HasMaxLength(4000);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductNameEn)
                .HasMaxLength(200)
                .HasColumnName("ProductNameEN");
        });

        modelBuilder.Entity<VwProductVariant>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwProductVariants");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CategoryNameEn)
                .HasMaxLength(100)
                .HasColumnName("CategoryNameEN");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrls).HasMaxLength(4000);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductNameEn)
                .HasMaxLength(200)
                .HasColumnName("ProductNameEN");
            entity.Property(e => e.Storages).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
