using System;

namespace DeliverySystem.OrderState;

public interface IOrderState
{
    void CheckOrder();
    void CancelOrder();
    void ProceedOrder();
}
