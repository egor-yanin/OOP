using System;

namespace DeliverySystem.CourierState;

public class AvailableState : ICourierState
{
    public void AcceptOrder(Courier courier, Order order)
    {
        Console.WriteLine($"Courier {courier.Name} accepted order {order.Code}");
        courier.SetState(new BusyState());
    }

    public void StartDelivery(Courier courier, Order order)
    {
        throw new InvalidOperationException("Courier must accept order first");
    }

    public void CompleteDelivery(Courier courier, Order order)
    {
        throw new InvalidOperationException("Courier is not delivering");
    }

    public string GetStatus() => "Available";
}