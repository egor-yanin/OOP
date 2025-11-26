using System;

namespace DeliverySystem.Order;

public interface IOrder
{
    string Name { get; }
    string Code { get; }

    float GetPrice();
}
