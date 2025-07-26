namespace back_end.Application.Models
{
    public class CategoryModel
    {
        public string CategoryCode { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string? CategoryNameEn { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
