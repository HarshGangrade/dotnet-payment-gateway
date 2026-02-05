//using PaymentGatewayProject.Models;

//namespace PaymentGatewayProject.Services
//{
//    public class PaymentService
//    {
//        public PaymentResult Process(decimal amount)
//        {
//            if (amount <= 0)
//                throw new ArgumentException("Invalid amount");

//            decimal finalAmount = amount;
//            bool feeApplied = false;

//            if (amount > 1000)
//            {
//                finalAmount = amount * 1.02m;
//                feeApplied = true;
//            }

//            return new PaymentResult
//            {
//                OriginalAmount = amount,
//                FinalAmount = finalAmount,
//                FeeApplied = feeApplied
//            };
//        }
//    }

//    public class PaymentResult
//    {
//        public decimal OriginalAmount { get; set; }
//        public decimal FinalAmount { get; set; }
//        public bool FeeApplied { get; set; }
//    }
//}


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
