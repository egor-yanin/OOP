using System;

namespace DeliverySystem.Dish;

public interface IDish
{
    string Name { get; }
    float Price { get; }
}
