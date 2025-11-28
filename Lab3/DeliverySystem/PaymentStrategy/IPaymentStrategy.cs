using System;

namespace DeliverySystem;

public interface IPaymentStrategy
{
    void Pay(float amount);
}
