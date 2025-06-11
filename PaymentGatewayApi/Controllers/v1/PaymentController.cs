using Microsoft.AspNetCore.Mvc;
using PaymentService.Business;
using PaymentService.Models.RequestModels;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentController(IPaymentBusiness paymentBusiness)
        {
            _paymentBusiness = paymentBusiness;
        }

        [HttpPost(Name = "init-payment-url")]
        public async Task<object> Get([FromBody]GetPaymentUrlRequest Req)
        {
            return await _paymentBusiness.GetPaymentUrlAsync(Req);
        }
    }
}
