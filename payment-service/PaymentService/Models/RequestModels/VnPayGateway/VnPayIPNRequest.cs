using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Models.RequestModels.VnPayGateway
{
    public class VnPayIPNRequest
    {

        [FromQuery(Name = "vnp_TmnCode")]
        public string TmnCode { get; set; }

        [FromQuery(Name = "vnp_Amount")]
        public decimal Amount { get; set; }

        [FromQuery(Name = "vnp_BankCode")]
        public string BankCode { get; set; }

        [FromQuery(Name = "vnp_BankTranNo")]
        public string BankTranNo { get; set; }

        [FromQuery(Name = "vnp_CardType")]
        public string CardType { get; set; }

        [FromQuery(Name = "vnp_PayDate")]
        public string PayDate { get; set; }

        [FromQuery(Name = "vnp_OrderInfo")]
        public string OrderInfo { get; set; }

        [FromQuery(Name = "vnp_TransactionNo")]
        public string TransactionNo { get; set; }

        [FromQuery(Name = "vnp_ResponseCode")]
        public string ResponseCode { get; set; }

        [FromQuery(Name = "vnp_TransactionStatus")]
        public string TransactionStatus { get; set; }

        [FromQuery(Name = "vnp_TxnRef")]
        public string TxnRef { get; set; }

        [FromQuery(Name = "vnp_SecureHash")]
        public string SecureHash { get; set; }

    }
}
