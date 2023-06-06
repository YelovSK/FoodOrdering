using FoodOrdering.Enums;

namespace FoodOrdering.Dto;

public class OrderDto
{
    public int Id { get; set; }
    
    public eOrderStatus Status { get; set; }

    public string Message { get; set; }
    
    public string StatusText => Status.ToString();

    public decimal TotalPrice => Items.Sum(i => i.Food.Price * i.Quantity);

    public List<FoodItemDto> Items { get; set; } = new();
}