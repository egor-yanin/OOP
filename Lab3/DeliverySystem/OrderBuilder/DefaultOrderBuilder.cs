using System;

namespace DeliverySystem.OrderBuilder;

public class DefaultOrderBuilder : IOrderBuilder
{
    private readonly DefaultOrder _order = new DefaultOrder();

    public IOrderBuilder SetCustomer(User user)
    {
        _order.Customer = user;
        return this;
    }

    public IOrderBuilder SetAddress(string address)
    {
        _order.Address = address;
        return this;
    }

    public IOrderBuilder SetDeliveryDate(DateTime deliveryDate)
    {
        _order.DeliveryDate = deliveryDate;
        return this;
    }

    public IOrderBuilder AddDish(IDish dish, int quantity)
    {
        _order.AddDish(dish, quantity);
        return this;
    }

    public Order Build()
    {
        return _order;
    }
}
