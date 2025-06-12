using Core.Models.ResponseModels;
using PaymentService.Models.RequestModels;

namespace PaymentService.Business
{
    public interface IPaymentBusiness
    {
        Task<BaseResonseModel<object>> GetPaymentUrlAsync(GetPaymentUrlRequest Req);
        Task<BaseResonseModel<object>> ProcessReturnUrlAsync();
        Task<BaseResonseModel<object>> ProcessIPNAsync(IPNRequest Req);
    }
}
