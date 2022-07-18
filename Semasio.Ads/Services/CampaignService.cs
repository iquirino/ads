using Semasio.Ads.Domain.Models;
using Semasio.Ads.Domain.Repositories;

namespace Semasio.Ads.Services
{
    public class CampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IStrategyRepository _strategyRepository;

        public CampaignService(ICampaignRepository campaignRepository, IStrategyRepository strategyRepository)
        {
            _campaignRepository = campaignRepository;
            _strategyRepository = strategyRepository;
        }

        public Task<Campaign> CreateCampaign(Campaign campaign)
        {
            return _campaignRepository.Create(campaign);
        }

        public Task<Campaign> UpdateCampaign(Campaign campaign)
        {
            return _campaignRepository.Update(campaign);
        }

        public Task<List<Campaign>> GetCampaigns()
        {
            return _campaignRepository.GetList();
        }

        public async Task ApplyPayment(Guid campaignId, float value)
        {
            var strategies = await _strategyRepository.GetByCampaignId(campaignId);

            var valueToAdd = value / strategies.Count;

            foreach (var strategy in strategies)
            {
                strategy.Balance += valueToAdd;
                await _strategyRepository.Update(strategy);
            }
        }

        public Task<Campaign?> GetCampaignById(Guid id)
        {
            return _campaignRepository.GetById(id);
        }

        public Task<List<Campaign>> GetCampaignsByUserId(Guid id)
        {
            return _campaignRepository.GetByUserId(id);
        }
    }
}
