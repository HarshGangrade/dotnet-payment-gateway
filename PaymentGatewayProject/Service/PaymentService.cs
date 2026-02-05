using PaymentGatewayProject.Models;
using PaymentGatewayProject.Service;

public class PaymentService : IPaymentService
{
    public PaymentResult Process(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Invalid amount");

        bool feeApplied = amount > 1000;
        decimal finalAmount = feeApplied ? amount * 1.02m : amount;

        return new PaymentResult
        {
            OriginalAmount = amount,
            FinalAmount = finalAmount,
            FeeApplied = feeApplied
        };
    }
}
