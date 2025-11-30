using System;

namespace DeliverySystem.OrderState;

public class CompletedState : IOrderState
{
    private Order _order;

    public CompletedState(Order order)
    {
        _order = order;
    }

    public string GetStatus() => "Completed";

    public void CheckOrder()
    {
        Console.WriteLine("Order is delivered.");
    }

    public void CancelOrder()
    {
        Console.WriteLine("Order cannot be canceled in Completed state.");
    }

    public void ProceedOrder()
    {
        Console.WriteLine("Order has been delivered.");
    }
}
