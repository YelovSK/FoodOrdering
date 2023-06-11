using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Order AddOrder(int userId, Cart cart);
}