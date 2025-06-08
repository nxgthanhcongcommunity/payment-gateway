using Core.Models.ResponseModels;

namespace PaymentService.Core
{
    public interface IPaymentGatewayService
    {
        Task<string> GetPaymentUrlAsync();
        Task<BaseResonseModel<object>> ProcessReturnUrlAsync();
        Task<BaseResonseModel<object>> ProcessIPNAsync();
    }
}
