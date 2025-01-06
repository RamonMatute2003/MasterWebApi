namespace MasterNet.Domain;

public record CoursePrice
{
    public Guid? CourseId { get; set; }
    public Course? Course { get; set; }

    public Guid? PriceId { get; set; }
    public Price? Price { get; set; }
}