using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Domain.Entities;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Infrastructure.Repositories;

public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Register(string username, string password)
    {
        if (await _db.Users.AnyAsync(u => u.Username == username))
            return false;

        _db.Users.Add(new User { Username = username, Password = password });
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Login(string username, string password)
    {
        return await _db.Users
            .AnyAsync(u => u.Username == username && u.Password == password);
    }
}
