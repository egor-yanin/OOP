using System;

namespace DeliverySystem.OrderState;

public class DeliveryState : IOrderState
{
    private Order _order;

    public DeliveryState(Order order)
    {
        _order = order;
    }

    public void CheckOrder()
    {
        Console.WriteLine("Order is out for delivery.");
    }

    public void CancelOrder()
    {
        Console.WriteLine("Order cannot be canceled in Delivery state.");
    }

    public void ProceedOrder()
    {
        _order.SetState(new CompletedState(_order));
    }
}
