using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.PaymentProcessor;

public abstract class PaymentProcessor
{
    protected readonly Order Order;
    
    protected PaymentProcessor(Order order)
    {
        Order = order;
    }

    public Order ProcessPayment()
    {
        PerformPayment();
        DisplayPaymentConfirmation();
        return Order;
    }

    protected abstract void PerformPayment();

    protected virtual void DisplayPaymentConfirmation()
    {
        Console.WriteLine("Payment processed successfully.");
    }
}