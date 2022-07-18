namespace Semasio.Ads.Domain.Models
{
    public class Strategy
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string Name { get; set; } = String.Empty;
        public StrategyType StrategyType { get; set; }
        public float Balance { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Restrictions { get; set; } = String.Empty;
    }
}
