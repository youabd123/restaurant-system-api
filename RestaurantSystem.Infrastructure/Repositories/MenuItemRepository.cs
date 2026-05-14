using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly AppDbContext _context;

    public MenuItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MenuItem>> GetAllAsync()
    {
        return await _context.MenuItems
            .AsNoTracking()
            .Include(menuItem => menuItem.Category)
            .ToListAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        return await _context.MenuItems
            .AsNoTracking()
            .Include(menuItem => menuItem.Category)
            .FirstOrDefaultAsync(menuItem => menuItem.Id == id);
    }

    public async Task<MenuItem> CreateAsync(MenuItem menuItem)
    {
        _context.MenuItems.Add(menuItem);
        await _context.SaveChangesAsync();

        return menuItem;
    }

    public async Task UpdateAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(MenuItem menuItem)
    {
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }
}
