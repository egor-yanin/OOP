using System;

namespace DeliverySystem.CourierState;

public class BusyState : ICourierState
{
    public void AcceptOrder(Courier courier, Order order)
    {
        throw new InvalidOperationException("Courier is already busy");
    }

    public void StartDelivery(Courier courier, Order order)
    {
        if (order.State != "Preparing")
        {
            throw new InvalidOperationException("Order is not ready for delivery");
        }
        order.ProceedOrder();
        Console.WriteLine($"Courier {courier.Name} started delivery of order {order.Code} to {order.Address}");
        courier.SetState(new DeliveringState());
    }

    public void CompleteDelivery(Courier courier, Order order)
    {
        throw new InvalidOperationException("Delivery has not started");
    }

    public string GetStatus() => "Busy";
}