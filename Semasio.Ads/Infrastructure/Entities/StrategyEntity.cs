using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semasio.Ads.DataAccess.Entities
{
    public class StrategyEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string Name { get; set; } = String.Empty;
        public StrategyType StrategyType { get; set; }
        public float Balance { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Restrictions { get; set; } = String.Empty;


        [ForeignKey(nameof(CampaignId))]
        public CampaignEntity? Campaign { get; set; }
    }
}
