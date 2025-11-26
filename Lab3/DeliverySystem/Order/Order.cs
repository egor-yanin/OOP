using System;
using DeliverySystem.OrderState;

namespace DeliverySystem.Order;

public abstract class Order
{
    public string Name { get; set; } = "";
    public string Code { get; protected set; } = "";
    private IOrderState _state;

    public Order()
    {
        _state = new PreparingState(this);
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public abstract float GetTotalPrice();

    public void CheckOrder()
    {
        _state.CheckOrder();
    }

    public void CancelOrder()
    {
        _state.CancelOrder();
    }

    public void ProceedOrder()
    {
        _state.ProceedOrder();
    }
}
