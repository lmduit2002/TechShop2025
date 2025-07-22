namespace back_end.Application.Models
{
    public class ProductModel
    {
        public string? CategoryCode { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductNameEn { get; set; }
        public string? Description { get; set; }
        public int ProductVersion { get; set; }
        public decimal? BasePrice { get; set; }
        public double? Rating { get; set; }
        public bool? IsActive { get; set; }
    }
}
