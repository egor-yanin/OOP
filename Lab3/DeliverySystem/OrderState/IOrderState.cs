using System;

namespace DeliverySystem.OrderState;

public interface IOrderState
{
    void CheckOrder();
    string GetStatus();
    void CancelOrder();
    void ProceedOrder();
}
