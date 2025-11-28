using System;

namespace DeliverySystem;

public interface IDiscount
{
    float ApplyDiscount(IDish dish);
}
