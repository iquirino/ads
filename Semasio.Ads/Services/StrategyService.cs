using MassTransit;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Domain.Repositories;

namespace Semasio.Ads.Services
{
    public class StrategyService
    {
        private readonly IStrategyRepository strategyRepository;

        public StrategyService(IStrategyRepository strategyRepository)
        {
            this.strategyRepository = strategyRepository;
        }

        public Task<Strategy> CreateStrategy(Strategy strategy)
        {
            return strategyRepository.Create(strategy);
        }

        public Task<Strategy> UpdateStrategy(Strategy strategy)
        {
            return strategyRepository.Update(strategy);
        }

        public async Task<Guid?> GetCampaignIdByUrl(string url, float? priceByPrint = null)
        {
            var ret = await strategyRepository.GetByUrl(url, priceByPrint.HasValue ? priceByPrint.Value : 0f);

            if(ret == null)
                return null;

            if(priceByPrint.HasValue && priceByPrint > 0)
            {
                ret.Balance -= priceByPrint.Value;

                var updated = await strategyRepository.Update(ret);

                return updated.Id;
            }

            return ret.Id;
        }

        internal Task<List<Strategy>> GetStrategys()
        {
            return strategyRepository.GetList();
        }

        public Task<Strategy?> GetStrategyById(Guid id)
        {
            return strategyRepository.GetById(id);
        }

        public Task<List<Strategy>> GetStrategyByCampaignId(Guid id)
        {
            return strategyRepository.GetByCampaignId(id);
        }
    }
}
