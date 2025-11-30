using System;

namespace DeliverySystem;

public class Courier
{
    public string Name { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public float Rating { get; protected set; } = 0.0f;

    public Courier(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public void SetRating(float rating)
    {
        Rating = rating;
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Courier {Name} is delivering order {order.Code} to {order.Address}");
    }
}
