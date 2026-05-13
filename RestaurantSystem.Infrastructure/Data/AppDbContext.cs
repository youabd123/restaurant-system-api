using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Konfigurera precision för valuta
        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(18, 2);

        // 2. Seed Categories (Restaurangens huvudkategorier)
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Pizzor", Description = "Klassiska stenugnsbakade pizzor" },
            new Category { Id = 2, Name = "Pasta", Description = "Färsk pasta med italienska råvaror" },
            new Category { Id = 3, Name = "Förrätter", Description = "Smått och gott att dela på" },
            new Category { Id = 4, Name = "Efterrätter", Description = "Söta avslutningar" },
            new Category { Id = 5, Name = "Dryck", Description = "Kalla drycker och läsk" }
        );

        // 3. Seed MenuItems (Exempelrätter kopplade till kategorierna ovan)
        modelBuilder.Entity<MenuItem>().HasData(
            // Pizzor (CategoryId = 1)
            new MenuItem { Id = 1, Name = "Margherita", Description = "Tomatsås, ost och basilika", Price = 95.00m, CategoryId = 1, IsAvailable = true },
            new MenuItem { Id = 2, Name = "Vesuvio", Description = "Tomatsås, ost och skinka", Price = 105.00m, CategoryId = 1, IsAvailable = true },

            // Pasta (CategoryId = 2)
            new MenuItem { Id = 3, Name = "Carbonara", Description = "Klassisk krämig sås med pancetta", Price = 135.00m, CategoryId = 2, IsAvailable = true },

            // Förrätter (CategoryId = 3)
            new MenuItem { Id = 4, Name = "Vitlöksbröd", Description = "Serveras med aioli", Price = 45.00m, CategoryId = 3, IsAvailable = true },

            // Efterrätter (CategoryId = 4)
            new MenuItem { Id = 5, Name = "Tiramisu", Description = "Klassisk italiensk efterrätt", Price = 75.00m, CategoryId = 4, IsAvailable = true },

            // Dryck (CategoryId = 5)
            new MenuItem { Id = 6, Name = "Coca Cola", Description = "33cl", Price = 25.00m, CategoryId = 5, IsAvailable = true },
            new MenuItem { Id = 7, Name = "Mineralvatten", Description = "33cl", Price = 20.00m, CategoryId = 5, IsAvailable = true }
        );
    }
}