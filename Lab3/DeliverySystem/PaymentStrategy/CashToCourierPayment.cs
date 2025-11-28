using System;

namespace DeliverySystem.PaymentStrategy;

public class CashToCourierPayment : IPaymentStrategy
{
    public void Pay(float amount)
    {
        Console.WriteLine($"Paid {amount} using cash to courier payment.");
    }
}
