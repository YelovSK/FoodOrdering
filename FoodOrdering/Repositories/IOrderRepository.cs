using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IOrderRepository
{
    public IEnumerable<Order> GetOrders();
    
    public Order GetOrder(int id);
    
    public void AddOrder(Order order);
    
    public void DeleteOrder(int id);
}