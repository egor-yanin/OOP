using System;

namespace DeliverySystem.OrderState;

public class PreparingState : IOrderState
{
    private Order _order;

    public PreparingState(Order order)
    {
        _order = order;
    }

    public string GetStatus() => "Preparing";

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
