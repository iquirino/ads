using AutoMapper;
using Semasio.Ads.DataAccess.Entities;
using Semasio.Ads.Domain.Models;

namespace Semasio.Ads.Infrastructure.Mappers
{
    public class EntityFrameworkMapperProfile : Profile
    {
        public EntityFrameworkMapperProfile()
        {
            CreateMap<Campaign, CampaignEntity>();
            CreateMap<Strategy, StrategyEntity>();
            CreateMap<CampaignEntity, Campaign>();
            CreateMap<StrategyEntity, Strategy>();
        }
    }
}
