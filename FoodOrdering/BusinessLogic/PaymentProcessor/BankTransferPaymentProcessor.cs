using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;

namespace FoodOrdering.BusinessLogic.PaymentProcessor;

public class BankTransferPaymentProcessor : PaymentProcessor
{
    public BankTransferPaymentProcessor(Order order) : base(order)
    {
    }

    protected override void PerformPayment()
    {
        if (Order.Status != eOrderStatus.Unpaid)
        {
            throw new FoodOrderingException("Order is not in unpaid state");
        }

        Order.Status = eOrderStatus.Paid;
        Order.Message = "Performed bank transfer payment";
        Console.WriteLine("Performing bank transfer payment...");
    }
}