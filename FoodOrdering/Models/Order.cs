using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrdering.Enums;

namespace FoodOrdering.Models;

public partial class Order
{
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public User User { get; set; }

    [Required]
    public eOrderStatus Status { get; set; } = eOrderStatus.Unpaid;

    public string Address { get; set; }
    
    public eDeliveryType DeliveryType { get; set; }
    
    public ICollection<OrderItem> Items { get; set; }
    
    public decimal TotalPrice => Items.Sum(f => f.Food.Price * f.Quantity);
}