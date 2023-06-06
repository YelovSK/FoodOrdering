using FoodOrdering.Enums;

namespace FoodOrdering.BusinessLogic.OrderState;

public class PaidOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Paid;

    public override void SetNextStatus(OrderContext context)
    {
        context.State = new DeliveredOrder();
    }
}