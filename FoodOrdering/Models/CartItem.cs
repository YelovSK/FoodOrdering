using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Models;

[PrimaryKey(nameof(CartId), nameof(FoodId))]
public class CartItem
{
    [Required]
    [ForeignKey(nameof(Cart))]
    public int CartId { get; set; }
    
    [Required]
    [ForeignKey(nameof(Food))]
    public int FoodId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    public Cart Cart { get; set; }
    
    public virtual Food Food { get; set; }
}