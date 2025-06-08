using Microsoft.Extensions.DependencyInjection;
using PaymentService.Gateways.VnPayGateway;
using PaymentService.Gateways.ZaloPayGateway;
using PaymentService.Models.EnumModels;

namespace PaymentService.Core
{
    public class PaymentGatewayResolver
    {
        private readonly IServiceProvider _provider;

        public PaymentGatewayResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IPaymentGatewayService GetGateway(string type) => type switch
        {
            PaymentGatewayTypeEnum.VNPay => _provider.GetRequiredService<IVnPayGatewayService>(),
            PaymentGatewayTypeEnum.ZaloPay => _provider.GetRequiredService<IZaloPayGatewayService>(),
            _ => throw new NotSupportedException("Gateway not supported")
        };
    }
}
