using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.OrderState;

public class PaidOrder : OrderState
{
    public override eOrderStatus GetOrderStatus() => eOrderStatus.Paid;

    public override void SetNextStatus(Order context)
    {
        context.State = new DeliveredOrder();
    }
}