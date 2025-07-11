﻿using Core.Helpers;
using Core.Models.GlobalModels;
using Core.Models.ResponseModels;
using Microsoft.Extensions.Options;
using PaymentService.Gateways.VnPayGateway;
using PaymentService.Models.RequestModels;
using PaymentService.Models.ResponseModels;

namespace PaymentService.Gateways.SePayGateway
{
    public class SePayGatewayService : ISePayGatewayService
    {

        private readonly SePayGatewayOptions _options;

        private readonly RequestContextData _requestContextData;

        public SePayGatewayService(IOptions<SePayGatewayOptions> options, RequestContextData requestContextData)
        {
            _options = options.Value;
            _requestContextData = requestContextData;
        }

        public async Task<string> GetPaymentUrlAsync(GetPaymentUrlRequest Req)
        {
            long orderId = 123444;
            string data = "123444_" + Req.OrderInfo.AccountCode; // xác định transaction này là cho user nào để +- tiền

            string encrypted = Helper.EncryptAes(data, _options.PriKey);

            return $"https://qr.sepay.vn/img?" +
               $"acc={_options.Stk}&" +
               $"bank={_options.Bank}&" +
               $"amount={Req.OrderInfo.Amount}&" +
               $"des={encrypted}&" +
               $"template={_options.Template}&" +
               $"download={_options.Download}";
        }

        public async Task<IPNResponse> ProcessIPNAsync(IPNRequest Req)
        {
            var sePayReq = Req.SePayRequest;

            // create transaction

            // get nội dung đơn hàng
            string decrypted = Helper.DecryptAes(sePayReq.Content, _options.PriKey);

            // 
            throw new NotImplementedException();
        }

        public async Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
