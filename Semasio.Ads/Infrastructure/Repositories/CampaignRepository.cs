using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semasio.Ads.DataAccess.Entities;
using Semasio.Ads.Domain.Models;
using Semasio.Ads.Domain.Repositories;

namespace Semasio.Ads.DataAccess.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly AdsDbContext _db;
        private readonly IMapper _mapper;

        public CampaignRepository(AdsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<Campaign>> GetList()
        {
            var ret = await _db.Campaigns.ToListAsync();
            return ret.Select(q => _mapper.Map<Campaign>(q)).ToList();
        }

        public async Task<Campaign?> GetById(Guid id)
        {
            return _mapper.Map<Campaign>(await _db.Campaigns.SingleOrDefaultAsync(q => q.Id == id));
        }

        public async Task<List<Campaign>> GetByUserId(Guid userId)
        {
            var ret = await _db.Campaigns.Where(q => q.UserId == userId).ToListAsync();
            return ret.Select(q => _mapper.Map<Campaign>(q)).ToList();
        }

        public async Task<Campaign> Create(Campaign campaign)
        {
            await _db.Campaigns.AddAsync(_mapper.Map<CampaignEntity>(campaign));
            await _db.SaveChangesAsync();
            return campaign;
        }

        public async Task<Campaign> Update(Campaign campaign)
        {
            _db.Campaigns.Update(_mapper.Map<CampaignEntity>(campaign));
            await _db.SaveChangesAsync();
            return campaign;
        }

        public async Task Delete(Campaign campaign)
        {
            _db.Campaigns.Remove(_mapper.Map<CampaignEntity>(campaign));
            await _db.SaveChangesAsync();
        }
    }
}
