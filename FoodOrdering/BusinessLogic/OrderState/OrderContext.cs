using FoodOrdering.Enums;
using FoodOrdering.Exceptions;

namespace FoodOrdering.BusinessLogic.OrderState;

public class OrderContext
{
    public OrderState State { get; set; }

    public eOrderStatus OrderStatus => State.GetOrderStatus();

    public OrderContext(OrderState state)
    {
        State = state;
    }
    
    public void SetNextStatus()
    {
        State.SetNextStatus(this);
    }

    public static OrderState GetState(eOrderStatus status)
    {
        switch (status)
        {
            case eOrderStatus.Unpaid:
                return new UnpaidOrder();
            case eOrderStatus.Paid:
                return new PaidOrder();
            case eOrderStatus.Delivered:
                return new DeliveredOrder();
            default:
                throw new FoodOrderingException("Invalid status");
        }
    }
}