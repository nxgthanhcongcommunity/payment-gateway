namespace PaymentService.Models.RequestModels
{
    public class GetPaymentUrlRequest
    {
        public string Provider { get; set; }
        public GetPaymentUrlOrderInfoRequest OrderInfo { get; set; }
        public VnPayGetPaymentUrlRequest VnPayRequest { get; set; }
    }

    public class GetPaymentUrlOrderInfoRequest
    {

    }

}
