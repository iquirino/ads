using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semasio.Ads.DataAccess.Entities;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Domain.Repositories;

namespace Semasio.Ads.DataAccess.Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly AdsDbContext _db;
        private readonly IMapper _mapper;
        public StrategyRepository(AdsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<Strategy>> GetList()
        {
            var ret = await _db.Strategies.ToListAsync();
            return ret.Select(q => _mapper.Map<Strategy>(q)).ToList();
        }

        public async Task<Strategy?> GetById(Guid id)
        {
            return _mapper.Map<Strategy>(await _db.Strategies.SingleOrDefaultAsync(q => q.Id == id));
        }

        public async Task<List<Strategy>> GetByCampaignId(Guid campaignId)
        {
            var ret = await _db.Strategies.Where(q => q.CampaignId == campaignId).ToListAsync();
            return ret.Select(q => _mapper.Map<Strategy>(q)).ToList();
        }

        public async Task<Strategy?> GetByUrl(string url, float priceByPrint)
        {
            return _mapper.Map<Strategy>(await _db.Strategies.Where(q =>
                q.Restrictions.Contains(url.ToLower())
                && q.Balance > priceByPrint
            ).FirstOrDefaultAsync());
        }

        public async Task<Strategy> Create(Strategy strategy)
        {
            await _db.Strategies.AddAsync(_mapper.Map<StrategyEntity>(strategy));
            await _db.SaveChangesAsync();
            return strategy;
        }

        public async Task<Strategy> Update(Strategy strategy)
        {
            _db.Strategies.Update(_mapper.Map<StrategyEntity>(strategy));
            await _db.SaveChangesAsync();
            return strategy;
        }

        public async Task Delete(Strategy strategy)
        {
            _db.Strategies.Remove(_mapper.Map<StrategyEntity>(strategy));
            await _db.SaveChangesAsync();
        }
    }
}
