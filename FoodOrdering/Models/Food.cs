using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Models;

public class Food
{
    public int Id { get; set; }

    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string Name { get; set; }
}