using MasterNet.Persistence;

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
        }
        catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<MasterNetDbContext>();
            logger.LogError(ex.Message);
        }
    }
}