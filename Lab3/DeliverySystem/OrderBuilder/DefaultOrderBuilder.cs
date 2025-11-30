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

    public IOrderBuilder SetCourier(Courier courier)
    {
        _order.Courier = courier;
        return this;
    }

    public IOrderBuilder SetAddress(string address)
    {
        _order.Address = address;
        return this;
    }

    public IOrderBuilder SetDeliveryDate(DateTime deliveryDate)
    {
        if (deliveryDate < DateTime.Now)
        {
            throw new ArgumentException("Delivery date cannot be in the past.");
        }
        _order.DeliveryDate = deliveryDate;
        return this;
    }

    public IOrderBuilder SetPaymentMethod(IPaymentStrategy paymentStrategy)
    {
        _order.SetPaymentStrategy(paymentStrategy);
        return this;
    }

    public IOrderBuilder SetDiscount(IDiscount discount)
    {
        _order.SetDiscount(discount);
        return this;
    }

    public IOrderBuilder AddDish(IDish dish, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }
        _order.AddDish(dish, quantity);
        return this;
    }

    public Order Build()
    {
        if (string.IsNullOrEmpty(_order.Address))
        {
            throw new InvalidOperationException("Address is required to build an order.");
        }
        if (_order.Customer == null)
        {
            throw new InvalidOperationException("Customer is required to build an order.");
        }
        if (_order.Courier == null)
        {
            throw new InvalidOperationException("Courier is required to build an order.");
        }
        if (_order.GetDishes().Count == 0)
        {
            throw new InvalidOperationException("At least one dish is required to build an order.");
        }

        _order.Code = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        return _order;
    }
}
