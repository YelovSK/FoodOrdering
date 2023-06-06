using FoodOrdering.Dto;
using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.Services;

public interface IOrderService
{
    public void UpdateOrderStatus(int orderId, eOrderStatus status);
    
    public void AdvanceOrderStatus(int orderId);
    
    public OrderDto AddOrder(int userId, Cart cart);
    
    public void PayOrder(int orderId);
    
    public OrderDto GetOrder(int id);
    
    public List<OrderDto> GetOrders(int userId);
}