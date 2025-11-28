using System;

namespace DeliverySystem.PaymentStrategy;

public class CardToCourierPayment : IPaymentStrategy
{
    public void Pay(float amount)
    {
        Console.WriteLine($"Paid {amount} using card to courier payment.");
    }
}
