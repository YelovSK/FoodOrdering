using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Models;

public class MyDbContext : DbContext
{
    private const string CONNECTION_STRING = @"Server=localhost;Port=5433;Database=postgres;User Id=yelov;Password=password;Include Error Detail=true;";

    public DbSet<User> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(CONNECTION_STRING);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Default include - don't do this in a real system xd
        builder.Entity<Cart>().Navigation(i => i.Items).AutoInclude();
        builder.Entity<Cart>().Navigation(i => i.User).AutoInclude();
        builder.Entity<CartItem>().Navigation(i => i.Cart).AutoInclude();
        builder.Entity<CartItem>().Navigation(i => i.Food).AutoInclude();
        builder.Entity<OrderItem>().Navigation(i => i.Order).AutoInclude();
        builder.Entity<OrderItem>().Navigation(i => i.Food).AutoInclude();
        builder.Entity<Order>().Navigation(i => i.Items).AutoInclude();
        builder.Entity<Order>().Navigation(i => i.User).AutoInclude();
        builder.Entity<User>().Navigation(i => i.Orders).AutoInclude();
        builder.Entity<User>().Navigation(i => i.Notifications).AutoInclude();
        
        // Seed users
        builder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Deez",
                Email = "address#domain.com",
                Address = "Vyštug 322",
            });

        // Seed carts
        builder.Entity<Cart>().HasData(
            new Cart
            {
                Id = 1,
                UserId = 1,
            });
        
        // Seed foods
        builder.Entity<Food>().HasData(
            new Food
            {
                Id = 1,
                Name = "Pizza",
                Price = 5.5m,
            },
            new Food
            {
                Id = 2,
                Name = "Burger",
                Price = 3.25m,
            },
            new Food
            {
                Id = 3,
                Name = "Fries",
                Price = 2m,
            },
            new Food
            {
                Id = 4,
                Name = "Hot-dog",
                Price = 1.5m,
            });
    }
}