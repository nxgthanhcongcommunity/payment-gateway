namespace PaymentService.Models.RequestModels
{
    public class VnPayGetPaymentUrlRequest
    {
        public decimal Amount { get; set; }
        public string BankCode { get; set; }
    }
}
