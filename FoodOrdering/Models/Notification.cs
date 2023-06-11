using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdering.Models;

public class Notification
{
    public int Id { get; set; }
    
    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    
    public DateTime SentDate { get; set; }
    
    public string Message { get; set; }
    
    public User User { get; set; }
}