using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}