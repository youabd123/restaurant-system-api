using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(AppDbContext context) : base(context)
    {
    }
}