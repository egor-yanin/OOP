using System;
using DeliverySystem.Order;

namespace DeliverySystem.OrderState;

public class PreparingState : IOrderState
{
    private Order.Order _order;

    public PreparingState(Order.Order order)
    {
        _order = order;
    }

    public void CheckOrder()
    {
        Console.WriteLine("Order is being prepared.");
    }

    public void CancelOrder()
    {
        Console.WriteLine("Order has been canceled from Preparing state.");
    }

    public void ProceedOrder()
    {
        _order.SetState(new DeliveryState(_order));
    }
}
