using FoodOrdering.Dto;
using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.Services;

public interface IOrderService
{
    public void AdvanceOrderStatus(int orderId);
    
    public OrderDto AddOrder(int userId, Cart cart, eDeliveryType deliveryType);
    
    public void PayOrder(int orderId, eOrderPaymentMethod eOrderPaymentMethod);
    
    public OrderDto GetOrder(int id);
    
    public List<OrderDto> GetOrders(int userId);
}