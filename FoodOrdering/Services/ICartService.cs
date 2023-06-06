using FoodOrdering.Dto;

namespace FoodOrdering.Services;

public interface ICartService
{
    CartDto GetCartByUserId(int userId);
    
    void AddItemToCart(int userId, int foodId, int quantity);

    void RemoveItemFromCart(int userId, int foodId);
}