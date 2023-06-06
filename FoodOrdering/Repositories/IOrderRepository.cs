using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IOrderRepository
{
    public IEnumerable<Order> GetOrders();

    public IEnumerable<Order> GetOrders(int userId);
    
    public Order? GetOrder(int id);
    
    public void UpdateOrderStatus(int orderId, eOrderStatus status);
    
    public Order AddOrder(int userId, Cart cart);
    
    public void DeleteOrder(int id);
    
    public void Save();
}