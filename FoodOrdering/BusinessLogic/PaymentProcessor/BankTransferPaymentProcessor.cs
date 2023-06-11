using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.PaymentProcessor;

public class BankTransferPaymentProcessor : PaymentProcessor
{
    public BankTransferPaymentProcessor(Order order, Notification notification) : base(order, notification)
    {
    }

    protected override void PerformPayment()
    {
        base.PerformPayment();

        Order.Status = eOrderStatus.Paid;
    }

    protected override void SetNotification()
    {
        Notification.Message = $"Performed bank transfer payment for order {Order.Id}";
        Order.User.Notifications.Add(Notification);
    }
}