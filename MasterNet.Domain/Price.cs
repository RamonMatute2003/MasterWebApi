namespace MasterNet.Domain;

public record Price : BaseEntity
{
    public string? Name { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal PromotionalPrice { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public ICollection<CoursePrice>? CoursePrices { get; set; }
}