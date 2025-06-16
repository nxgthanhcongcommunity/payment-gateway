using PaymentService.Models.RequestModels.SePayGateway;
using PaymentService.Models.RequestModels.VnPayGateway;

namespace PaymentService.Models.RequestModels
{
    public class IPNRequest
    {
        public string Provider { get; set; }
        public VnPayIPNRequest VnPayRequest { get; set; }
        public SePayIPNRequest SePayRequest { get; set; }
    }
}
