using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.DeliveryStrategy;

public class BranchDelivery : IDeliveryStrategy
{
    private const string DUMMY_BRANCH_ADDRESS = "Restaurant 322, Uganda";
    
    public void SetDelivery(Order order)
    {
        order.DeliveryType = eDeliveryType.BranchDelivery;
        order.Address = GetClosestBranchAddress();
        order.User.Notifications.Add(new Notification
        {
            UserId = order.User.Id,
            SentDate = DateTime.UtcNow,
            Message = $"Delivery of order {order.Id} is set to {DUMMY_BRANCH_ADDRESS}",
        });
    }

    private string GetClosestBranchAddress()
    {
        // Um, imagine some logic here
        return DUMMY_BRANCH_ADDRESS;
    }
}