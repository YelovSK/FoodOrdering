using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.OrderState;

public abstract class OrderState
{
    public abstract eOrderStatus GetOrderStatus();

    public abstract void SetNextStatus(Order context);
}