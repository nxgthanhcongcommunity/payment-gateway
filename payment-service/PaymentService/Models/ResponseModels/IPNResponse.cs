using PaymentService.Models.ResponseModels.SePayGateway;
using PaymentService.Models.ResponseModels.VnPayGateway;

namespace PaymentService.Models.ResponseModels
{
    public class IPNResponse
    {
        public VnPayIPNResponse VnPayResponse { get; set; }
        public SePayIPNResponse SePayResponse { get; set; }
    }
}
