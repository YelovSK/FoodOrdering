using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(MyDbContext context) : base(context)
    {
    }
}