using Bogus;
using MasterNet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MasterNet.Persistence;

public class MasterNetDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalDatabase.db")
        .LogTo(
                Console.WriteLine, 
                [DbLoggerCategory.Database.Command.Name], 
                Microsoft.Extensions.Logging.LogLevel.Information
            ).EnableSensitiveDataLogging()
             .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>().ToTable("courses");
        modelBuilder.Entity<Instructor>().ToTable("instructors");
        modelBuilder.Entity<CourseInstructor>().ToTable("courseInstructors");
        modelBuilder.Entity<Price>().ToTable("prices");
        modelBuilder.Entity<CoursePrice>().ToTable("coursePrices");
        modelBuilder.Entity<Evaluation>().ToTable("evaluations");
        modelBuilder.Entity<Photo>().ToTable("images");

        modelBuilder.Entity<Price>()
            .Property(b => b.CurrentPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Price>()
            .Property(b => b.PromotionalPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Price>()
            .Property(b => b.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(250);

        modelBuilder.Entity<Course>()
            .HasMany(m => m.Photos)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(m => m.Evaluations)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Course>()
            .HasMany(m => m.Prices)
            .WithMany(m => m.Courses)
            .UsingEntity<CoursePrice>(
                j => j
                    .HasOne(p => p.Price)
                    .WithMany(p => p.CoursePrices)
                    .HasForeignKey(p => p.PriceId),
                j => j
                     .HasOne(p => p.Course)
                     .WithMany(p => p.CoursePrices)
                     .HasForeignKey(p => p.CourseId),
                j =>
                {
                    j.HasKey(t => new { t.PriceId, t.CourseId });
                }
            );

        modelBuilder.Entity<Course>()
            .HasMany(m => m.Instructors)
            .WithMany(m => m.Courses)
            .UsingEntity<CourseInstructor>(
                j => j
                    .HasOne(p => p.Instructor)
                    .WithMany(p => p.CoursesInstructors)
                    .HasForeignKey(p => p.InstructorId),
                j => j
                     .HasOne(p => p.Course)
                     .WithMany(p => p.CourseInstructors)
                     .HasForeignKey(p => p.CourseId),
                j =>
                {
                    j.HasKey(t => new { t.InstructorId, t.CourseId });
                }
            );

        modelBuilder.Entity<Course>().HasData(DataMaster().Item1);
        modelBuilder.Entity<Price>().HasData(DataMaster().Item2);
        modelBuilder.Entity<Instructor>().HasData(DataMaster().Item3);
    }

    public Tuple<Course[], Price[], Instructor[]> DataMaster()
    {
        var courses = new List<Course>();
        var faker = new Faker();

        for(int i = 1; i < 10; i++)
        {
            var courseId = Guid.NewGuid();

            courses.Add(
                new Course 
                {
                    Id = courseId,
                    Description = faker.Commerce.ProductDescription(),
                    Title = faker.Commerce.ProductName(),
                    PublicationDate = DateTime.UtcNow,
                }
            );
        }

        var priceId = Guid.NewGuid();
        var price = new Price
        {
            Id= priceId,
            CurrentPrice = 10.0m,
            PromotionalPrice = 8.0m,
            Name = "Precio Regular"
        };

        var prices = new List<Price>()
        {
            price
        };

        var fakerInstructor = new Faker<Instructor>()
            .RuleFor(t => t.Id, _ => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.Name.FirstName())
            .RuleFor(t => t.LastName, f => f.Name.LastName())
            .RuleFor(t => t.Grade, f => f.Name.JobTitle());

        var instructors = fakerInstructor.Generate(10);

        return Tuple.Create(courses.ToArray(), prices.ToArray(), instructors.ToArray());
    }
}