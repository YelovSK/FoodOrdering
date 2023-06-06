using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class FoodRepository : RepositoryBase, IFoodRepository
{
    public FoodRepository(MyDbContext context) : base(context)
    {
    }

    public Food? GetFood(int foodId)
    {
        return _context.Foods.SingleOrDefault(i => i.Id == foodId);
    }
}