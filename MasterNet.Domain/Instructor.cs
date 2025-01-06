namespace MasterNet.Domain;

public record Instructor : BaseEntity
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Grade { get; set; }

    public ICollection<Course>? Courses { get; set; }
    public ICollection<CourseInstructor>? CoursesInstructors { get; set; }
}