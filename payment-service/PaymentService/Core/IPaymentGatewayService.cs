using Core.Models.ResponseModels;
using PaymentService.Models.RequestModels;

namespace PaymentService.Core
{
    public interface IPaymentGatewayService
    {
        Task<string> GetPaymentUrlAsync(GetPaymentUrlRequest Req);
        Task<BaseResonseModel<object>> ProcessReturnUrlAsync();
        Task<BaseResonseModel<object>> ProcessIPNAsync();
    }
}
