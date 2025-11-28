using System;

namespace DeliverySystem.Discount;

public class NoDiscount : IDiscount
{
    public float ApplyDiscount(IDish dish)
    {
        return dish.Price;
    }
}
