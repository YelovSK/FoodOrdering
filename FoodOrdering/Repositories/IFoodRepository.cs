using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IFoodRepository
{
    Food? GetFood(int foodId);
    
    void Save();
}