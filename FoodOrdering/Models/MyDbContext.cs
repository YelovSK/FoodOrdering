using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Models;

public class MyDbContext : DbContext
{
    private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ordering;Integrated Security=True;Connect Timeout=30;";

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed users table
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
            });
        
        // Seed orders
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                UserId = 1,
            });
    }
}