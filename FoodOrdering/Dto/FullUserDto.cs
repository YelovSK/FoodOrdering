namespace FoodOrdering.Dto;


public class UserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; }
}

public class FullUserDto : UserDto
{
    public List<OrderDto> Orders { get; set; } = new();
    
    public List<NotificationDto> Notifications { get; set; } = new();
}