using Microsoft.AspNetCore.Mvc;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Services;

namespace Semasio.Strategys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StrategyController : Controller
    {
        private readonly StrategyService strategyService;

        public StrategyController(StrategyService strategyService)
        {
            this.strategyService = strategyService;
        }

        [HttpGet()]
        public Task<List<Strategy>> GetStrategys()
        {
            return strategyService.GetStrategys();
        }

        [HttpGet("{id}")]
        public Task<Strategy?> GetStrategyById(Guid id)
        {
            return strategyService.GetStrategyById(id);
        }

        [HttpGet("Campaign/{id}")]
        public Task<List<Strategy>> GetStrategyByCampaignId(Guid id)
        {
            return strategyService.GetStrategyByCampaignId(id);
        }

        [HttpPost]
        public Task<Strategy> NewStrategy(Strategy strategy)
        {
            return strategyService.CreateStrategy(strategy);
        }

        [HttpPut("{id}")]
        public Task<Strategy> UpdateStrategy(Guid id, Strategy strategy)
        {
            return strategyService.UpdateStrategy(strategy);
        }
    }
}
