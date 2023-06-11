using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.PaymentProcessor;

public class OnlineBankingPaymentProcessor : PaymentProcessor
{
    public OnlineBankingPaymentProcessor(Order order, Notification notification) : base(order, notification)
    {
    }

    protected override void PerformPayment()
    {
        base.PerformPayment();

        Order.Status = eOrderStatus.Paid;
    }

    protected override void SetNotification()
    {
        Notification.Message = $"Performed online banking payment for order {Order.Id}";
        Order.User.Notifications.Add(Notification);
    }
}