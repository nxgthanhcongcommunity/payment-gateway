using Core.Models.ResponseModels;
using PaymentService.Core;
using PaymentService.Models.RequestModels;
using PaymentService.Models.ResponseModels;

namespace PaymentService.Gateways.ZaloPayGateway
{
    public class ZaloPayGatewayService : IZaloPayGatewayService
    {
        public async Task<string> GetPaymentUrlAsync(GetPaymentUrlRequest Req)
        {
            return "okasd zalo";
        }

        public Task<IPNResponse> ProcessIPNAsync(IPNRequest Req)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
