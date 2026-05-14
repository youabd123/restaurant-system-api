using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RestaurantSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registrerar MediatR
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        return services;
    }
}