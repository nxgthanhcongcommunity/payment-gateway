using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Business;
using PaymentService.Core;
using PaymentService.Gateways.SePayGateway;
using PaymentService.Gateways.VnPayGateway;
using PaymentService.Gateways.ZaloPayGateway;

namespace PaymentService
{
    public static class PaymentServiceRegistrationExtension
    {
        public static IServiceCollection AddPaymentServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.Configure<VnPayGatewayOptions>(configuration.GetSection("Gateways:VnPay"));
            services.AddScoped<IVnPayGatewayService, VnPayGatewayService>();

            services.AddScoped<IZaloPayGatewayService, ZaloPayGatewayService>();

            services.Configure<SePayGatewayOptions>(configuration.GetSection("Gateways:SePay"));
            services.AddScoped<ISePayGatewayService, SePayGatewayService>();

            services.AddScoped<PaymentGatewayResolver>();

            services.AddScoped<IPaymentBusiness, PaymentBusiness>();

            return services;
        }
    }
}
