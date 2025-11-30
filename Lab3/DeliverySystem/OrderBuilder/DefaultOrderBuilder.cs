using System;

namespace DeliverySystem.OrderBuilder;

public class DefaultOrderBuilder : IOrderBuilder
{
    private OrderValidator _validator = new OrderValidator();
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
        try
        {
            _validator.ValidateDeliveryDate(deliveryDate);
        }
        catch (ArgumentException ex)
        {
            throw new InvalidOperationException("Invalid delivery date: " + ex.Message);
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
        try
        {
            _validator.ValidateDishes(_order);
        }
        catch (ArgumentException ex)
        {
            throw new InvalidOperationException("Invalid dish addition: " + ex.Message);
        }
        _order.AddDish(dish, quantity);
        return this;
    }

    public Order Build()
    {
        _order.Code = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        try
        {
            _validator.ValidateOrderBuilder(_order);
        }
        catch (ArgumentException ex)
        {
            throw new InvalidOperationException("Order build failed: " + ex.Message);
        }
        return _order;
    }
}
