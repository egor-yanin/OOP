using System;

namespace DeliverySystem.PaymentStrategy;

public class OnlinePayment : IPaymentStrategy
{
    public void Pay(float amount)
    {
        Console.WriteLine($"Paid {amount} using online payment.");
    }
}
