using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class FoodRepository : GenericRepository<Food>, IFoodRepository
{
    public FoodRepository(MyDbContext context) : base(context)
    {
    }
}