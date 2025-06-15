namespace PaymentService.Gateways.SePayGateway
{
    public class SePayGatewayOptions
    {
        public string PriKey { get; set; } = default!;
        public string Stk { get; set; } = default!;
        public string Bank { get; set; } = default!;
        public string Template { get; set; } = default!;
        public string Download { get; set; } = default!;
    }
}
