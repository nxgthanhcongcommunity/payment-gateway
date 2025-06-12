using Core.Models.ResponseModels;
using PaymentService.Models.RequestModels;
using PaymentService.Models.ResponseModels;

namespace PaymentService.Core
{
    public interface IPaymentGatewayService
    {
        Task<string> GetPaymentUrlAsync(GetPaymentUrlRequest Req);
        Task<IPNResponse> ProcessIPNAsync(IPNRequest Req);
        Task<BaseResonseModel<object>> ProcessReturnUrlAsync();
    }
}
