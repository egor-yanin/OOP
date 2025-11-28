using System;

namespace DeliverySystem.Discount;

public class CategoryDiscount : IDiscount
{
    private readonly float _discountPercentage;
    private readonly string _category;

    public CategoryDiscount(string category, float discountPercentage)
    {
        _category = category;
        _discountPercentage = discountPercentage;
    }

    public float ApplyDiscount(IDish dish)
    {
        if (dish.Category == _category)
        {
            return dish.Price * (1 - _discountPercentage / 100);
        }
        return dish.Price;
    }
}
