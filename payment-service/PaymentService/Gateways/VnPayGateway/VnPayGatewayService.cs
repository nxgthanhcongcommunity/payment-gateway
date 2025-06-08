using Core.Models.ResponseModels;
using PaymentService.Core;

namespace PaymentService.Gateways.VnPayGateway
{
    public class VnPayGatewayService : IVnPayGatewayService
    {
        public async Task<string> GetPaymentUrlAsync()
        {
            return "okasd vnpay";
        }

        public Task<BaseResonseModel<object>> ProcessIPNAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
