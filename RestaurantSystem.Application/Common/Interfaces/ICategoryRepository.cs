using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category> CreateAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(Category category);
}
