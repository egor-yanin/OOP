using System;
using DeliverySystem.OrderState;
using DeliverySystem.PaymentStrategy;

namespace DeliverySystem;

public abstract class Order
{
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public User Customer { get; set; } = new User();
    protected readonly Dictionary<IDish, int> _dishes = new Dictionary<IDish, int>();
    public string Address { get; set; } = "";
    public DateTime DeliveryDate { get; set; } = DateTime.Now;
    private IOrderState _state;
    private IPaymentStrategy _paymentStrategy;

    public Order()
    {
        _state = new InitializingState(this);
        _paymentStrategy = new OnlinePayment();
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
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

    public void AddDish(IDish dish, int quantity)
    {
        if (_dishes.ContainsKey(dish))
        {
            _dishes[dish] += quantity;
        }
        else
        {
            _dishes[dish] = quantity;
        }
    }

    public void RemoveDish(IDish dish)
    {
        if (_dishes.ContainsKey(dish))
        {
            _dishes.Remove(dish);
        }
    }
}
