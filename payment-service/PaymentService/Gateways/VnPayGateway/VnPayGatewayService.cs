using Core.Models.GlobalModels;
using Core.Models.ResponseModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PaymentService.Models.RequestModels;
using PaymentService.Models.ResponseModels;
using PaymentService.Models.ResponseModels.VnPayGateway;
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

        public async Task<IPNResponse> ProcessIPNAsync(IPNRequest Req)
        {
            string vnp_HashSecret = _options.HashSecret; //Secret key
            VnPayGatewayLibrary vnpay = new VnPayGatewayLibrary();


            foreach (var prop in Req.VnPayRequest.GetType().GetProperties())
            {
                var name = prop.Name;
                var value = prop.GetValue(Req.VnPayRequest);

                vnpay.AddResponseData($"vnp_{name}", "" + value);
            }

            //Lay danh sach tham so tra ve tu VNPAY
            //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
            //vnp_TransactionNo: Ma GD tai he thong VNPAY
            //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
            //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

            long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
            long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
            long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            String vnp_SecureHash = Req.VnPayRequest.SecureHash;
            
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
            if (checkSignature == false) 
            {
                return new IPNResponse
                {
                    VnPayResponse = new VnPayIPNResponse
                    {
                        RspCode = "97",
                        Message = "Invalid signature"
                    }
                };
            }

            return new IPNResponse
            {
                VnPayResponse = new VnPayIPNResponse
                {
                    RspCode = "00",
                    Message = "asd",
                }
            };
        }

        public Task<BaseResonseModel<object>> ProcessReturnUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
