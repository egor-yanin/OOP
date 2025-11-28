using System;

namespace DeliverySystem.OrderState;

public class InitializingState : IOrderState
{
    private Order _order;

    public InitializingState(Order order)
    {
        _order = order;
    }

    public void CheckOrder()
    {
        Console.WriteLine("Order is being checked.");
    }

    public void CancelOrder()
    {
        Console.WriteLine("Order has been canceled.");
    }

    public void ProceedOrder()
    {
        _order.SetState(new PreparingState(_order));
    }
}
