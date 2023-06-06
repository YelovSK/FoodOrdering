using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface ICartRepository
{
    Cart? GetCartByUserId(int userId);
    
    void AddFoodToCart(int cartId, int foodId, int quantity);

    void RemoveItem(int itemFoodId, int itemCartId);

    void Save();
}