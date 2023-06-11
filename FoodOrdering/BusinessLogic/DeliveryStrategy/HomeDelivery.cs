using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.DeliveryStrategy;

public class HomeDelivery : IDeliveryStrategy
{
    public void SetDelivery(Order order)
    {
        order.DeliveryType = eDeliveryType.HomeDelivery;
        order.Address = order.User.Address;
        order.User.Notifications.Add(new Notification
        {
            UserId = order.User.Id,
            SentDate = DateTime.UtcNow,
            Message = $"Delivery of order {order.Id} is set to home delivery",
        });
    }
}