namespace MasterNet.Domain;

public record Photo : BaseEntity
{
    public string? Url { get; set; }
    
    public Guid? CourseId { get; set; }
    public Course? Course { get; set; }
}