using Microsoft.EntityFrameworkCore;
using Semasio.Payments.DataAccess.Models;

namespace Semasio.Payments.DataAccess.Repositories
{
    public class PaymentRepository
    {
        private readonly PaymentDbContext db;
        public PaymentRepository(PaymentDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Payment>> GetList()
        {
            return await db.Payments.ToListAsync();
        }

        public async Task<Payment?> GetById(Guid id)
        {
            return await db.Payments.SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Payment>> GetByUserId(Guid userId)
        {
            return await db.Payments.Where(q => q.UserId == userId).ToListAsync();
        }

        public async Task<List<Payment>> GetByCampaignId(Guid campaignId)
        {
            return await db.Payments.Where(q => q.CampaignId == campaignId).ToListAsync();
        }

        public async Task<Payment> Create(Payment payment)
        {
            await db.Payments.AddAsync(payment);
            await db.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> Update(Payment payment)
        {
            db.Payments.Update(payment);
            await db.SaveChangesAsync();
            return payment;
        }

        public async Task Delete(Payment payment)
        {
            db.Payments.Remove(payment);
            await db.SaveChangesAsync();
        }
    }
}
