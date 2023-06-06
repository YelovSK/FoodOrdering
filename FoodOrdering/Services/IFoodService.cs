using FoodOrdering.Dto;

namespace FoodOrdering.Services;

public interface IFoodService
{
    FoodDto GetFood(int foodId);
}