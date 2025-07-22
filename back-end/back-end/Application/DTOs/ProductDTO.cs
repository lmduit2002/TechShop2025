namespace back_end.Application.DTOs
{
    public class ProductFilterDTO
    {
        public string? CategoryName { get; set; } = string.Empty;
        public string? CategoryNameEn { get; set; } = string.Empty;
        public string? ProductName { get; set; } = string.Empty;
        public string? ProductNameEn { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal? BasePrice { get; set; }
    }
}
