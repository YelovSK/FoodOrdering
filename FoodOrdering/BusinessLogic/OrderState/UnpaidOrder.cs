using FoodOrdering.Enums;

namespace FoodOrdering.BusinessLogic.OrderState;

public class UnpaidOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Unpaid;

    public override void SetNextStatus(OrderContext context)
    {
        context.State = new PaidOrder();
    }
}