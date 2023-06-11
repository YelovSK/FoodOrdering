using FoodOrdering.BusinessLogic.DeliveryStrategy;
using FoodOrdering.Models;

namespace FoodOrdering.Services;

public class DeliveryService
{
    private readonly Order order;
    private IDeliveryStrategy strategy;

    public DeliveryService(Order order, IDeliveryStrategy strategy)
    {
        this.order = order;
        this.strategy = strategy;
    }

    public void Execute()
    {
        strategy.SetDelivery(order);
    }
}