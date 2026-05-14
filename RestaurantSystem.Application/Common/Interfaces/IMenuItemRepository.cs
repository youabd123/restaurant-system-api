using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Interfaces;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAllAsync();

    Task<MenuItem?> GetByIdAsync(int id);

    Task<MenuItem> CreateAsync(MenuItem menuItem);

    Task UpdateAsync(MenuItem menuItem);

    Task DeleteAsync(MenuItem menuItem);
}
