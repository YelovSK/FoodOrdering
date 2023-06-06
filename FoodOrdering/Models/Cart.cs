using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdering.Models;

public class Cart
{
    public int Id { get; set; }
    
    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public ICollection<CartItem> Items { get; set; }

    public decimal TotalPrice => Items.Sum(f => f.Food.Price * f.Quantity);
}
