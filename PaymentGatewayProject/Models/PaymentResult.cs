namespace PaymentGatewayProject.Models
{
    public class PaymentResult
    {
        public decimal OriginalAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public bool FeeApplied { get; set; }
    }
}
