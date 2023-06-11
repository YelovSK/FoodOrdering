using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.DeliveryStrategy;

public class BranchDelivery : IDeliveryStrategy
{
    private const string RANDOM_BRANCH_ADDRESS_I_GUESS = "Random branch address";
    
    public void SetDelivery(Order order)
    {
        order.DeliveryType = eDeliveryType.BranchDelivery;
        order.Address = GetClosestBranchAddress();
        order.User.Notifications.Add(new Notification
        {
            UserId = order.User.Id,
            SentDate = DateTime.UtcNow,
            Message = $"Delivery of order {order.Id} is set to {RANDOM_BRANCH_ADDRESS_I_GUESS}",
        });
    }

    private string GetClosestBranchAddress()
    {
        // Imagine some logic here
        return RANDOM_BRANCH_ADDRESS_I_GUESS;
    }
}