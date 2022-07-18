using Semasio.Ads.Domain.Models;

namespace Semasio.Ads.Domain.Repositories
{
    public interface IStrategyRepository
    {
        Task<Strategy> Create(Strategy strategy);
        Task Delete(Strategy strategy);
        Task<List<Strategy>> GetByCampaignId(Guid campaignId);
        Task<Strategy?> GetById(Guid id);
        Task<Strategy?> GetByUrl(string url, float priceByPrint);
        Task<List<Strategy>> GetList();
        Task<Strategy> Update(Strategy strategy);
    }
}