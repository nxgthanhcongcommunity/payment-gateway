namespace PaymentService.Models.RequestModels.SePayGateway
{
    public class SePayIPNRequest
    {
        public int Id { get; set; }                            // ID giao dịch trên SePay
        public string Gateway { get; set; }                    // Brand name của ngân hàng
        public string TransactionDate { get; set; }          // Thời gian giao dịch
        public string AccountNumber { get; set; }              // Số tài khoản ngân hàng
        public string Code { get; set; }                       // Mã code thanh toán
        public string Content { get; set; }                    // Nội dung chuyển khoản
        public string TransferType { get; set; }               // in / out
        public decimal TransferAmount { get; set; }            // Số tiền giao dịch
        public decimal Accumulated { get; set; }               // Số dư lũy kế
        public string SubAccount { get; set; }                 // Tài khoản phụ (nếu có)
        public string ReferenceCode { get; set; }              // Mã tham chiếu
        public string Description { get; set; }                // Mô tả toàn bộ từ notify
    }
}
