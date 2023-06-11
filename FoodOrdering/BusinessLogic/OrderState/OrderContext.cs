using System.ComponentModel.DataAnnotations.Schema;
using FoodOrdering.BusinessLogic.OrderState;
using FoodOrdering.Enums;
using FoodOrdering.Exceptions;

namespace FoodOrdering.Models;

public partial class Order
{
    [NotMapped]
    public OrderState? State { get; set; }
    
    public void SetNextStatus()
    {
        State ??= GetState(Status);

        State.SetNextStatus(this);
    }

    public void UpdateState()
    {
        State ??= GetState(Status);

        Status = State.GetOrderStatus();
    }
    
    private static OrderState GetState(eOrderStatus status)
    {
        return status switch
        {
            eOrderStatus.Unpaid    => new UnpaidOrder(),
            eOrderStatus.Paid      => new PaidOrder(),
            eOrderStatus.Delivered => new DeliveredOrder(),
            _                      => throw new FoodOrderingException("Invalid status")
        };
    }
}