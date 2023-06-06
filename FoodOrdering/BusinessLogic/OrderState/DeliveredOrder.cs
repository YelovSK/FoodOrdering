using FoodOrdering.Enums;
using FoodOrdering.Exceptions;

namespace FoodOrdering.BusinessLogic.OrderState;

public class DeliveredOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Delivered;

    public override void SetNextStatus(OrderContext context)
    {
        throw new FoodOrderingException("There is no next state for delivered order.");
    }
}