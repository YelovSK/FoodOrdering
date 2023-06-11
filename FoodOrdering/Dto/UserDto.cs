namespace FoodOrdering.Dto;


public class UserInfoDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => FirstName + " " + LastName;

    public string Email { get; set; }
}

public class UserDto : UserInfoDto
{
    public List<OrderDto> Orders { get; set; } = new();
    
    public List<NotificationDto> Notifications { get; set; } = new();
}