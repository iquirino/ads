using Microsoft.AspNetCore.Mvc;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Services;

namespace Semasio.Ads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdsController
    {
        private readonly CampaignService _campaignService;
        private readonly StrategyService _strategyService;

        public AdsController(StrategyService strategyService, CampaignService campaignService)
        {
            _strategyService = strategyService;
            _campaignService = campaignService;
        }

        [HttpGet("online")]
        public async Task<Campaign?> GetOnlineCampaign(string url)
        {
            var campaignId = await _strategyService.GetCampaignIdByUrl(url, 0.001f);

            if(!campaignId.HasValue)
                return null;

            return await _campaignService.GetCampaignById(campaignId.Value);
        }

        [HttpGet("tv")]
        public Task<Campaign> GetTvCampaign(string channel)
        {
            throw new NotImplementedException("How could i implement it here? hahaha");
        }

        [HttpGet("outdoor")]
        public Task<Campaign> GetOutdoorCampaign(string latitude, string longitude)
        {
            throw new NotImplementedException("How could i implement it here? hahaha");
        }
    }
}
