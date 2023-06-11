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

    public string Email { get; set; }
    
    public string Address { get; set; }

    public ICollection<Order> Orders { get; set; }
    
    public ICollection<Notification> Notifications { get; set; }
}