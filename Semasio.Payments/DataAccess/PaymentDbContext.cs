using Microsoft.EntityFrameworkCore;
using Semasio.Payments.DataAccess.Models;

namespace Semasio.Payments.DataAccess
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }
    }
}
