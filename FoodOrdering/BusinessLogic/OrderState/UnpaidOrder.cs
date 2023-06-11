using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.OrderState;

public class UnpaidOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Unpaid;

    public override void SetNextStatus(Order context)
    {
        context.State = new PaidOrder();
    }
}