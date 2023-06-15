using FoodOrdering.BusinessLogic.DeliveryStrategy;
using FoodOrdering.Models;

namespace FoodOrdering.Services;

public class DeliveryService
{
    private readonly Order _order;
    private readonly IDeliveryStrategy _strategy;

    public DeliveryService(Order order, IDeliveryStrategy strategy)
    {
        _order = order;
        _strategy = strategy;
    }

    public void Execute()
    {
        _strategy.SetDelivery(_order);
    }
}