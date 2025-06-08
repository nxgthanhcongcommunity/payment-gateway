using Core.Models.ResponseModels;
using PaymentService.Core;

namespace PaymentService.Gateways.ZaloPayGateway
{
    public class ZaloPayGatewayService : IZaloPayGatewayService
    {
        public async Task<string> GetPaymentUrlAsync()
        {
            return "okasd zalo";
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
