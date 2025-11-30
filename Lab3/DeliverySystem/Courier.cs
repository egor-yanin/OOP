using System;

namespace DeliverySystem;

public class Courier
{
    public string Name { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    private Order _currentOrder = null!;
    public float Rating { get; protected set; } = 0.0f;
    private ICourierState _state = new CourierState.AvailableState();

    public Courier(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public void SetRating(float rating)
    {
        Rating = rating;
    }

    public void SetState(ICourierState state)
    {
        _state = state;
    }

    public void AcceptOrder(Order order)
    {
        _state.AcceptOrder(this, order);
        _currentOrder = order;
    }

    public void StartDelivery()
    {
        _state.StartDelivery(this, _currentOrder);
    }

    public void CompleteDelivery()
    {
        _state.CompleteDelivery(this, _currentOrder);
        _currentOrder = null!;
    }
}
