using Semasio.Ads.Domain.Models;

namespace Semasio.Ads.Domain.Repositories
{
    public interface ICampaignRepository
    {
        Task<Campaign> Create(Campaign campaign);
        Task Delete(Campaign campaign);
        Task<Campaign?> GetById(Guid id);
        Task<List<Campaign>> GetByUserId(Guid userId);
        Task<List<Campaign>> GetList();
        Task<Campaign> Update(Campaign campaign);
    }
}