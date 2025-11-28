using System;

namespace DeliverySystem;

public class DefaultOrder : Order
{
    public override float GetTotalPrice()
    {
        float total = 0;
        foreach (var dish in _dishes)
        {
            total += dish.Key.Price * dish.Value;
        }
        return total;
    }
}
