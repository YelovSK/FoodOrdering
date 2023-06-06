using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrdering.Enums;

namespace FoodOrdering.Models;

public class Order
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;
    
    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public User User { get; set; }

    [Required]
    public eOrderStatus Status { get; set; } = eOrderStatus.Unpaid;

    public ICollection<OrderItem> Items { get; set; }
    
    public decimal TotalPrice => Items.Sum(f => f.Food.Price * f.Quantity);
}