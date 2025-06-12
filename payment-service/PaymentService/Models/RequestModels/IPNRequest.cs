using PaymentService.Models.RequestModels.VnPayGateway;

namespace PaymentService.Models.RequestModels
{
    public class IPNRequest
    {
        public string Provider { get; set; }
        public VnPayIPNRequest VnPayRequest { get; set; }
    }
}
