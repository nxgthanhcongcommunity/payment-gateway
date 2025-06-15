using Core.Controllers;
using Core.Helpers;
using Core.Models.GlobalModels;
using Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Business;
using PaymentService.Models.RequestModels;
using PaymentService.Models.RequestModels.VnPayGateway;
using PaymentService.Models.ResponseModels;
using System.Text.Json;

namespace PaymentGatewayApi.Controllers.v1
{
    [ApiController]
    [Route("v1/payment-gateway")]
    public class PaymentController : BaseController
    {

        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentController(
            RequestContextData requestContextData,
            IPaymentBusiness paymentBusiness
            ) : base( requestContextData )
        {
            _paymentBusiness = paymentBusiness;
        }

        [HttpPost("init-payment-url")]
        public async Task<object> Get([FromBody]GetPaymentUrlRequest Req)
        {
            return await HandleRequestAsync(_paymentBusiness.GetPaymentUrlAsync(Req));
        }

        [HttpGet("vnpay-process-ipn")]
        public async Task<object> Get([FromQuery] VnPayIPNRequest Req)
        {
            var IPNRequest = new IPNRequest
            {
                Provider = "VnPay",
                VnPayRequest = Req,
            };
            //return await HandleRequestAsync(_paymentBusiness.ProcessIPNAsync(IPNRequest));

            var rs = await _paymentBusiness.ProcessIPNAsync(IPNRequest);

            var rs1 = rs.Data as IPNResponse;

            return rs1?.VnPayResponse;
        }

    }

}
