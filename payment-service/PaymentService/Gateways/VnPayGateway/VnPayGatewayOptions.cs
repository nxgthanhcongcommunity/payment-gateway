namespace PaymentService.Gateways.VnPayGateway
{
    public class VnPayGatewayOptions
    {
        public string TmnCode { get; set; } = default!;
        public string HashSecret { get; set; } = default!;
        public string ReturnUrl { get; set; } = default!;
        public string PaymentUrl { get; set; } = default!;
        public string Version { get; set; } = default!;
        public string Command { get; set; } = default!;
        public string CurrCode { get; set; } = default!;
        public string Locale { get; set; } = default!;
    }
}
