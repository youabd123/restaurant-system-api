using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}