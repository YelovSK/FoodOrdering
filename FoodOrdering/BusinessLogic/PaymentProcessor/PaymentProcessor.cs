using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.PaymentProcessor;

public abstract class PaymentProcessor
{
    protected readonly Order Order;
    protected readonly Notification Notification;
    
    protected PaymentProcessor(Order order, Notification notification)
    {
        Order = order;
        Notification = notification;
    }

    public Order ProcessPayment()
    {
        PerformPayment();
        SetNotification();
        return Order;
    }

    protected virtual void PerformPayment()
    {
        if (Order.Status != eOrderStatus.Unpaid)
        {
            throw new FoodOrderingException("Order is not in unpaid state");
        }
    }

    protected abstract void SetNotification();
}