using System;

namespace DeliverySystem;

public interface ICourierState
{
    void AcceptOrder(Courier courier, Order order);
    void StartDelivery(Courier courier, Order order);
    void CompleteDelivery(Courier courier, Order order);
    string GetStatus();
}
