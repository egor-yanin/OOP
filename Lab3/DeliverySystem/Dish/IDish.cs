using System;

namespace DeliverySystem;

public interface IDish
{
    string Name { get; }
    string Category { get; }
    float Price { get; }
    float Weight { get; }
    float Calorage { get; }
}
