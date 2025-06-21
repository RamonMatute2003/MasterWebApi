using Bogus;
using MasterNet.Domain;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MasterNet.Persistence;

public class MasterNetDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }

    public MasterNetDbContext(DbContextOptions<MasterNetDbContext> options) : base(options) { }

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

        modelBuilder.Entity<Course>().HasData(LoadDataMaster().Item1);
        modelBuilder.Entity<Price>().HasData(LoadDataMaster().Item2);
        modelBuilder.Entity<Instructor>().HasData(LoadDataMaster().Item3);

        LoadDataSecurity(modelBuilder);
    }

    private static void LoadDataSecurity(ModelBuilder modelBuilder)
    {
        var adminId = Guid.NewGuid().ToString();
        var clientId = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminId,
                Name = CustomRoles.ADMIN,
                NormalizedName = CustomRoles.ADMIN
            }
        );

        modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole
           {
               Id = clientId,
               Name = CustomRoles.CLIENT,
               NormalizedName = CustomRoles.CLIENT
           }
        );

        modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
           new IdentityRoleClaim<string>
           {
               Id = 1,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COURSE_READ,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 2,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COURSE_UPDATE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 3,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COURSE_WRITE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 4,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COURSE_DELETE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 5,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.INSTRUCTOR_CREATE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 6,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.INSTRUCTOR_READ,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 7,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.INSTRUCTOR_UPDATE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 8,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COMMENT_READ,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 9,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COMMENT_DELETE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 10,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COMMENT_CREATE,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 11,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COURSE_READ,
               RoleId = clientId
           },
           new IdentityRoleClaim<string>
           {
               Id = 12,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.INSTRUCTOR_READ,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 13,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COMMENT_READ,
               RoleId = adminId
           },
           new IdentityRoleClaim<string>
           {
               Id = 14,
               ClaimType = CustomClaims.POLICES,
               ClaimValue = PolicyMaster.COMMENT_CREATE,
               RoleId = adminId
           }
        );
    }

    private static Tuple<Course[], Price[], Instructor[]> LoadDataMaster()
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