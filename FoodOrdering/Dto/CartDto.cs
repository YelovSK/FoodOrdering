namespace FoodOrdering.Dto;

public class CartDto
{
    public int Id { get; set; }

    public decimal TotalPrice => Items.Sum(f => f.Food.Price * f.Quantity);

    public List<FoodItemDto> Items { get; set; } = new();
}