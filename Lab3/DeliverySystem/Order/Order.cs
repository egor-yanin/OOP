using System;
using DeliverySystem.OrderState;

namespace DeliverySystem;

public abstract class Order
{
    public string Name { get; set; } = "";
    public string Code { get; protected set; } = "";
    public User Customer { get; protected set; } = new User();
    protected readonly Dictionary<IDish, int> _dishes = new Dictionary<IDish, int>();
    public string Address { get; protected set; } = "";
    public DateTime DeliveryDate { get; protected set; } = DateTime.Now;
    private IOrderState _state;

    public Order()
    {
        _state = new PaymentState(this);
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
