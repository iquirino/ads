using Microsoft.AspNetCore.Mvc;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Services;

namespace Semasio.Campaigns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : Controller
    {
        private readonly CampaignService campaignService;

        public CampaignController(CampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [HttpGet()]
        public Task<List<Campaign>> GetCampaigns()
        {
            return campaignService.GetCampaigns();
        }

        [HttpGet("{id}")]
        public Task<Campaign?> GetCampaignById(Guid id)
        {
            return campaignService.GetCampaignById(id);
        }

        [HttpGet("User/{id}")]
        public Task<List<Campaign>> GetCampaignsByUserId(Guid id)
        {
            return campaignService.GetCampaignsByUserId(id);
        }

        [HttpPost]
        public Task<Campaign> NewCampaign(Campaign campaign)
        {
            return campaignService.CreateCampaign(campaign);
        }

        [HttpPut("{id}")]
        public Task<Campaign> UpdateCampaign(Guid id, Campaign campaign)
        {
            return campaignService.UpdateCampaign(campaign);
        }
    }
}
