namespace PaymentService.Models.RequestModels.VnPayGateway
{
    public class VnPayGetPaymentUrlRequest
    {
        public decimal Amount { get; set; } = 12000;
        public string BankCode { get; set; } = "VNBANK";
    }
}
