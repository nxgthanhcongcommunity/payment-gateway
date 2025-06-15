using PaymentService.Models.RequestModels.VnPayGateway;

namespace PaymentService.Models.RequestModels
{
    public class GetPaymentUrlRequest
    {
        /// <example>VnPay</example>
        public string Provider { get; set; }
        public GetPaymentUrlOrderInfoRequest OrderInfo { get; set; }
        public VnPayGetPaymentUrlRequest VnPayRequest { get; set; }
    }

    public class GetPaymentUrlOrderInfoRequest
    {
        public string AccountCode { get; set; }
        public decimal Amount { get; set; }
    }

}
