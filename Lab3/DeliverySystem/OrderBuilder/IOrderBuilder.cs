using System;

namespace DeliverySystem;

public interface IOrderBuilder
{
    IOrderBuilder SetCustomer(User user);
    IOrderBuilder SetAddress(string address);
    IOrderBuilder SetDeliveryDate(DateTime deliveryDate);
    IOrderBuilder AddDish(IDish dish, int quantity);
    Order Build();
}
