using System;

namespace DeliverySystem.Discount;

public class DishDiscount : IDiscount
{
    private readonly float _discountPercentage;
    private readonly string _dishName;

    public DishDiscount(string dishName, float discountPercentage)
    {
        _discountPercentage = discountPercentage;
        _dishName = dishName;
    }

    public float ApplyDiscount(IDish dish)
    {
        if (dish.Name == _dishName)
        {
            return dish.Price * (1 - _discountPercentage / 100);
        }
        return dish.Price;
    }
}
