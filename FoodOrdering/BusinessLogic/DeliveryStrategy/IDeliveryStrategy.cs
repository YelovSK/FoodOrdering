using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.DeliveryStrategy;

public interface IDeliveryStrategy
{
    void SetDelivery(Order order);
}