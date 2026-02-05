using PaymentGatewayProject.Models;

namespace PaymentGatewayProject.Service
{
    public interface IPaymentService
    {
        PaymentResult Process(decimal amount);
    }
}

