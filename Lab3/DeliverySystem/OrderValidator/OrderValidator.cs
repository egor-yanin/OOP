using System;

namespace DeliverySystem;

public class OrderValidator
{
    public void ValidateCustomer(User user)
    {
        if (user == null)
        {
            throw new ArgumentException("Customer information is required.");
        }
    }

    public void ValidateAddress(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException("Address is required.");
        }
    }

    public void ValidateDeliveryDate(DateTime deliveryDate)
    {
        if (deliveryDate < DateTime.Now)
        {
            throw new ArgumentException("Delivery date cannot be in the past.");
        }
    }

    public void ValidateDishes(Order order)
    {
        if (order.GetDishes().Count == 0)
        {
            throw new ArgumentException("At least one dish must be added to the order.");
        }
    }

    public void ValidateCourier(User courier)
    {
        if (courier == null)
        {
            throw new ArgumentException("Courier information is required.");
        }
    }

    public void ValidateOrderBuilder(Order order)
    {
        ValidateCustomer(order.Customer);
        ValidateAddress(order.Address);
        ValidateDishes(order);
    }
}
