using System;

namespace DeliverySystem;

public class DefaultOrder : Order
{
    public override float GetTotalPrice()
    {
        float total = 0;
        foreach (var dish in _dishes)
        {
            total += _discount.ApplyDiscount(dish.Key) * dish.Value;
        }
        return total;
    }
}
