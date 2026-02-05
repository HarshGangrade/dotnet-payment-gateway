//namespace PaymentGatewayProject.Models
//{
//    public class PaymentResult
//    {
//        public decimal OriginalAmount { get; set; }
//        public decimal FinalAmount { get; set; }
//        public bool FeeApplied { get; set; }
//    }
//}

namespace PaymentGatewayProject.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
    }
}
