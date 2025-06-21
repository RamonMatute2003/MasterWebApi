using Microsoft.Extensions.DependencyInjection;

namespace MasterNet.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
    )
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependecyInjection).Assembly);
        });

        return services;
    }
}