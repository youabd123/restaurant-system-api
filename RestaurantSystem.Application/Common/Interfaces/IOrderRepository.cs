using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();

    Task<Order?> GetByIdAsync(int id);

    Task<Order> CreateAsync(Order order);

    Task UpdateAsync(Order order);

    Task DeleteAsync(Order order);
}
