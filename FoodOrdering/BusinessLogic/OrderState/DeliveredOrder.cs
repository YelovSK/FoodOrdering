using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.OrderState;

public class DeliveredOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Delivered;

    public override void SetNextStatus(Order context)
    {
        throw new FoodOrderingException("There is no next state for delivered order.");
    }
}