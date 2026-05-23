using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<AppUser>
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

        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Pizzor", Description = "Klassiska stenugnsbakade pizzor" },
            new Category { Id = 2, Name = "Pasta", Description = "Färsk pasta med italienska råvaror" },
            new Category { Id = 3, Name = "Sallader", Description = "Fräscha sallader med lokala råvaror" },
            new Category { Id = 4, Name = "Förrätter", Description = "Smått och gott att dela på" },
            new Category { Id = 5, Name = "Kött & Fisk", Description = "Grillade rätter från land och hav" },
            new Category { Id = 6, Name = "Efterrätter", Description = "Söta avslutningar" },
            new Category { Id = 7, Name = "Dryck", Description = "Kalla drycker och läsk" },
            new Category { Id = 8, Name = "Viner", Description = "Noggrant utvalda viner" }
        );

        modelBuilder.Entity<MenuItem>().HasData(
            // Pizzor
            new MenuItem { Id = 1, Name = "Margherita", Description = "Tomatsås, mozzarella och färsk basilika", Price = 115.00m, CategoryId = 1, IsAvailable = true },
            new MenuItem { Id = 2, Name = "Vesuvio", Description = "Tomatsås, mozzarella och parmaskinka", Price = 135.00m, CategoryId = 1, IsAvailable = true },
            new MenuItem { Id = 3, Name = "Quattro Stagioni", Description = "Tomatsås, mozzarella, skinka, champinjoner, oliver och kronärtskocka", Price = 145.00m, CategoryId = 1, IsAvailable = true },
            new MenuItem { Id = 4, Name = "Diavola", Description = "Tomatsås, mozzarella och salami piccante", Price = 140.00m, CategoryId = 1, IsAvailable = true },
            new MenuItem { Id = 5, Name = "Tartufo", Description = "Tryffelkräm, mozzarella, porcini och rucola", Price = 165.00m, CategoryId = 1, IsAvailable = true },

            // Pasta
            new MenuItem { Id = 6, Name = "Spaghetti Carbonara", Description = "Klassisk krämig sås med pancetta och pecorino", Price = 145.00m, CategoryId = 2, IsAvailable = true },
            new MenuItem { Id = 7, Name = "Tagliatelle Bolognese", Description = "Långsamt kokt köttfärssås med parmesan", Price = 150.00m, CategoryId = 2, IsAvailable = true },
            new MenuItem { Id = 8, Name = "Penne Arrabiata", Description = "Kryddig tomatsås med vitlök och chili", Price = 130.00m, CategoryId = 2, IsAvailable = true },
            new MenuItem { Id = 9, Name = "Gnocchi al Pesto", Description = "Hemgjorda gnocchi med basilikopesto och körsbärstomater", Price = 155.00m, CategoryId = 2, IsAvailable = true },

            // Sallader
            new MenuItem { Id = 10, Name = "Caesar Sallad", Description = "Romansallad, krutonger, parmesan och caesardressing", Price = 115.00m, CategoryId = 3, IsAvailable = true },
            new MenuItem { Id = 11, Name = "Caprese", Description = "Buffelmozzarella, tomater, basilika och olivolja", Price = 125.00m, CategoryId = 3, IsAvailable = true },
            new MenuItem { Id = 12, Name = "Rucola & Parmesan", Description = "Rucola, parmesanflagor, valnötter och balsamicodressing", Price = 110.00m, CategoryId = 3, IsAvailable = true },

            // Förrätter
            new MenuItem { Id = 13, Name = "Vitlöksbröd", Description = "Rostat bröd med vitlökssmör och örter", Price = 55.00m, CategoryId = 4, IsAvailable = true },
            new MenuItem { Id = 14, Name = "Bruschetta", Description = "Rostade brödschivor med tomater, vitlök och basilika", Price = 65.00m, CategoryId = 4, IsAvailable = true },
            new MenuItem { Id = 15, Name = "Carpaccio", Description = "Tunnskivad oxfilé med rucola, parmesan och tryffelolja", Price = 145.00m, CategoryId = 4, IsAvailable = true },
            new MenuItem { Id = 16, Name = "Burrata", Description = "Krämig burrata med rostade tomater och pesto", Price = 135.00m, CategoryId = 4, IsAvailable = true },

            // Kött & Fisk
            new MenuItem { Id = 17, Name = "Tagliata di Manzo", Description = "Grillad oxfilé med rucola, parmesan och tryffelolja", Price = 285.00m, CategoryId = 5, IsAvailable = true },
            new MenuItem { Id = 18, Name = "Branzino al Forno", Description = "Ugnsbakad havsabborre med citron och kapris", Price = 245.00m, CategoryId = 5, IsAvailable = true },
            new MenuItem { Id = 19, Name = "Pollo alla Griglia", Description = "Grillad kycklingbröst med rosmarin och citron", Price = 195.00m, CategoryId = 5, IsAvailable = true },
            new MenuItem { Id = 20, Name = "Gamberi al Aglio", Description = "Vitlöksstekta räkor med chili och persilja", Price = 225.00m, CategoryId = 5, IsAvailable = true },

            // Efterrätter
            new MenuItem { Id = 21, Name = "Tiramisu", Description = "Klassisk italiensk efterrätt med mascarpone", Price = 85.00m, CategoryId = 6, IsAvailable = true },
            new MenuItem { Id = 22, Name = "Panna Cotta", Description = "Vaniljpannacotta med hallonsås", Price = 75.00m, CategoryId = 6, IsAvailable = true },
            new MenuItem { Id = 23, Name = "Gelato", Description = "Tre kulor italiensk glass, välj smak", Price = 65.00m, CategoryId = 6, IsAvailable = true },
            new MenuItem { Id = 24, Name = "Cannoli", Description = "Krispiga rör med ricottakräm och pistaschnötter", Price = 70.00m, CategoryId = 6, IsAvailable = true },

            // Dryck
            new MenuItem { Id = 25, Name = "Coca Cola", Description = "33cl", Price = 35.00m, CategoryId = 7, IsAvailable = true },
            new MenuItem { Id = 26, Name = "Mineralvatten", Description = "Sparkling eller still, 33cl", Price = 30.00m, CategoryId = 7, IsAvailable = true },
            new MenuItem { Id = 27, Name = "Freshly Squeezed Juice", Description = "Pressad apelsin- eller citronjuice", Price = 55.00m, CategoryId = 7, IsAvailable = true },
            new MenuItem { Id = 28, Name = "Espresso", Description = "Klassisk italiensk espresso", Price = 35.00m, CategoryId = 7, IsAvailable = true },
            new MenuItem { Id = 29, Name = "Cappuccino", Description = "Espresso med mjölkskum", Price = 45.00m, CategoryId = 7, IsAvailable = true },

            // Viner
            new MenuItem { Id = 30, Name = "Chianti Classico", Description = "Toscansk rödvin, glas", Price = 95.00m, CategoryId = 8, IsAvailable = true },
            new MenuItem { Id = 31, Name = "Pinot Grigio", Description = "Friskt vitt vin från Norditalien, glas", Price = 85.00m, CategoryId = 8, IsAvailable = true },
            new MenuItem { Id = 32, Name = "Prosecco", Description = "Italienskt mousserande vin, glas", Price = 90.00m, CategoryId = 8, IsAvailable = true }
        );

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
        );
    }
}