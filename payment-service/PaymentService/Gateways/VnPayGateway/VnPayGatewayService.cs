using Core.Models.GlobalModels;
using Core.Models.ResponseModels;
using Microsoft.Extensions.Options;
using PaymentService.Models.RequestModels;
using System.Text.Json;

namespace PaymentService.Gateways.VnPayGateway
{
    public class VnPayGatewayService : IVnPayGatewayService
    {

        private readonly VnPayGatewayOptions _options;

        private readonly RequestContextData _requestContextData;

        public VnPayGatewayService(IOptions<VnPayGatewayOptions> options, RequestContextData requestContextData)
        {
            _options = options.Value;
            _requestContextData = requestContextData;
        }

        public async Task<string> GetPaymentUrlAsync(GetPaymentUrlRequest Req)
        {
            Console.WriteLine(JsonSerializer.Serialize(_requestContextData));

            //Get Config Info
            string vnp_Returnurl = _options.ReturnUrl; //URL nhan ket qua tra ve 
            string vnp_Url = _options.PaymentUrl; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _options.TmnCode; //Ma định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = _options.HashSecret; //Secret Key

            //Get payment input ====== temp!!!!!
            //OrderInfo order = new OrderInfo();
            //order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            //order.Amount = 100000; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
            //order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
            //order.CreatedDate = DateTime.Now;

            VnPayGatewayLibrary vnpay = new VnPayGatewayLibrary();
            vnpay.AddRequestData("vnp_Version", _options.Version);
            vnpay.AddRequestData("vnp_Command", _options.Command);
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (Req.VnPayRequest.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnpay.AddRequestData("vnp_BankCode", Req.VnPayRequest.BankCode);

            //TODO 1!!
            vnpay.AddRequestData("vnp_CreateDate", DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _options.CurrCode.ToUpper());
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            vnpay.AddRequestData("vnp_Locale", _options.Locale);

            //TODO 1!!
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + "111");
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

            vnpay.AddRequestData("vnp_ReturnUrl", _options.ReturnUrl);
            //TODO 1!!
            vnpay.AddRequestData("vnp_TxnRef", "111"); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            return paymentUrl;
        }

        public Task<BaseResonseModel<object>> ProcessIPNAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
