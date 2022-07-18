using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Semasio.Ads.DataAccess.Entities;

namespace Semasio.Ads.DataAccess
{
    public class AdsDbContext : DbContext
    {
        public DbSet<CampaignEntity> Campaigns { get; set; }
        public DbSet<StrategyEntity> Strategies { get; set; }

        public AdsDbContext(DbContextOptions<AdsDbContext> options) : base(options)
        {

        }
    }
}
