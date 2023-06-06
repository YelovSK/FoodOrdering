using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Models;

[PrimaryKey(nameof(OrderId), nameof(FoodId))]
public class OrderItem
{
    [Required]
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    
    [Required]
    [ForeignKey(nameof(Food))]
    public int FoodId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    public Order Order { get; set; }
    
    public Food Food { get; set; }
}