using Bogus;

using MasterNet.Domain;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.WebApi.Extensions;

public static class DataSeed
{
    public static async Task SeedDataAuthentication(
        this IApplicationBuilder applicationBuilder
    )
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<MasterNetDbContext>();
            await context.Database.MigrateAsync();
            var userManager = service.GetRequiredService<UserManager<AppUser>>();

            if(!userManager.Users.Any())
            {
                var userAdmin = new AppUser
                {
                    FullName = "Ariel Matute",
                    UserName = "arielm",
                    Email = "ariel.matute@gmail.com",
                };

                var userClient = new AppUser
                {
                    FullName = "Ramon Matute",
                    UserName = "ramonm",
                    Email = "ramon.matute@gmail.com",
                };

                await userManager.CreateAsync(userAdmin, "Pasword$123");
                await userManager.AddToRoleAsync(userAdmin, CustomRoles.ADMIN);
                await userManager.CreateAsync(userClient, "Pasword$123");
                await userManager.AddToRoleAsync(userClient, CustomRoles.CLIENT);
            }

            var courses = await context.Courses!.Take(10).Skip(10).ToListAsync();

            if(!context.Set<CourseInstructor>().Any())
            {
                var instructors = await context.Instructors!.Take(10).Skip(10).ToListAsync();

                foreach(var course in courses)
                {
                    course.Instructors = instructors;
                }
            }

            if(!context.Set<CoursePrice>().Any())
            {
                var prices = await context.Prices!.ToListAsync();

                foreach(var course in courses)
                {
                    course.Prices = prices;
                }
            }

            if(!context.Set<Evaluation>().Any())
            {
                foreach(var course in courses)
                {
                    var fakerEvaluation = new Faker<Evaluation>()
                        .RuleFor(c => c.Id, _ => Guid.NewGuid())
                        .RuleFor(c => c.Student, s => s.Name.FullName())
                        .RuleFor(c => c.Comment, s => s.Commerce.ProductDescription())
                        .RuleFor(c => c.Score, 5)
                        .RuleFor(c => c.CourseId, course.Id);

                    var evaluations = fakerEvaluation.Generate(10);
                    context.AddRange(evaluations);
                }
            }

            await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<MasterNetDbContext>();
            logger.LogError(ex.Message);
        }
    }
}