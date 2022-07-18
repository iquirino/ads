namespace Semasio.Payments.Contracts
{
    public class PaymentConfirmedMessage
    {
        public Guid CampaignId { get; set; }
        public Guid PaymentId { get; set; }
        public float Value { get; set; }
    }
}
