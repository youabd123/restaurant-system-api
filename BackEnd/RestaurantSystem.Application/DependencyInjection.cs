using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using RestaurantSystem.Application.Common.Behaviors;
using RestaurantSystem.Application.Common.Mappings;

namespace RestaurantSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

        return services;
    }
}