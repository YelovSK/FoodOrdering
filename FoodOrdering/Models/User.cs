using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string FullName => FirstName + " " + LastName;

    public virtual List<Order> Orders { get; set; }
}