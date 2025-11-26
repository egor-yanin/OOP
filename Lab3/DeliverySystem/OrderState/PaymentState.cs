using System;

namespace DeliverySystem.OrderState;

public class PaymentState : IOrderState
{
    private Order.Order _order;

    public PaymentState(Order.Order order)
    {
        _order = order;
    }

    public void CheckOrder()
    {
        Console.WriteLine("Order is awaiting payment.");
    }

    public void CancelOrder()
    {
        Console.WriteLine("Order has been canceled from Payment state.");
    }

    public void ProceedOrder()
    {
        _order.SetState(new PreparingState(_order));
    }
}
