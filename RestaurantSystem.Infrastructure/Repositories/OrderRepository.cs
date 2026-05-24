using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Order>> GetAllAsync()

    {
        return await _context.Orders
            .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
            .ToListAsync();
    }

    public override async Task<Order?> GetByIdAsync(int id)

    {
        return await _context.Orders
            .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
            .FirstOrDefaultAsync(order => order.Id == id);
    }
}
