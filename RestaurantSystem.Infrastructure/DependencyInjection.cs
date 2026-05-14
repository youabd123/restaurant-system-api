using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Infrastructure.Data;
using RestaurantSystem.Infrastructure.Repositories;

namespace RestaurantSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Här kopplas dina repositories ihop
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();

        return services;
    }
}