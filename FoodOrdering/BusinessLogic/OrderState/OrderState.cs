using FoodOrdering.Enums;

namespace FoodOrdering.BusinessLogic.OrderState;

public abstract class OrderState
{
    public abstract eOrderStatus GetOrderStatus();

    public abstract void SetNextStatus(OrderContext context);
}