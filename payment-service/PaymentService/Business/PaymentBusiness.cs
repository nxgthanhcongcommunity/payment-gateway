using Core.Models.ResponseModels;
using PaymentService.Core;
using PaymentService.Models.EnumModels;
using PaymentService.Models.RequestModels;

namespace PaymentService.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly PaymentGatewayResolver _paymentGatewayResolver;

        public PaymentBusiness(PaymentGatewayResolver paymentGatewayResolver) 
        {
            _paymentGatewayResolver = paymentGatewayResolver;
        }

        public async Task<BaseResonseModel<object>> GetPaymentUrlAsync(GetPaymentUrlRequest Req)
        {
            var gw = _paymentGatewayResolver.GetGateway(Req.Provider);

            var rs = await gw.GetPaymentUrlAsync(Req);

            return BaseResonseModel<object>.Success(rs);
        }

        public async Task<BaseResonseModel<object>> ProcessIPNAsync(IPNRequest Req)
        {
            var gw = _paymentGatewayResolver.GetGateway(Req.Provider);

            var rs = await gw.ProcessIPNAsync(Req);

            return BaseResonseModel<object>.Success(rs);
        }

        public Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
