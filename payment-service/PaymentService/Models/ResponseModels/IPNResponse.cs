using PaymentService.Models.ResponseModels.VnPayGateway;

namespace PaymentService.Models.ResponseModels
{
    public class IPNResponse
    {
        public VnPayIPNResponse VnPayResponse { get; set; }
    }
}
