using System;

namespace DeliverySystem.CourierState;

public class DeliveringState : ICourierState
{
    public void AcceptOrder(Courier courier, Order order)
    {
        throw new InvalidOperationException("Courier is already delivering");
    }

    public void StartDelivery(Courier courier, Order order)
    {
        throw new InvalidOperationException("Delivery already started");
    }

    public void CompleteDelivery(Courier courier, Order order)
    {
        Console.WriteLine($"Courier {courier.Name} completed delivery of order {order.Code}");
        courier.SetState(new AvailableState());
    }

    public string GetStatus() => "Delivering";
}