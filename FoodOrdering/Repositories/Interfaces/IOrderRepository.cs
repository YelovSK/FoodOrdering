using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    public void UpdateOrderStatus(int orderId, eOrderStatus status);

    Order AddOrder(int userId, Cart cart);
}