using MassTransit;
using Semasio.Payments.Contracts;
using Semasio.Payments.DataAccess.Models;
using Semasio.Payments.DataAccess.Repositories;

namespace Semasio.Payments.Services
{
    public class PaymentService
    {
        private readonly IBus bus;
        private readonly PaymentRepository paymentRepository;

        public PaymentService(IBus bus, PaymentRepository paymentRepository)
        {
            this.bus = bus;
            this.paymentRepository = paymentRepository;
        }

        public Task<Payment> InitiatePayment(Payment payment)
        {
            payment.PaymentStatus = PaymentStatus.Pending;
            return paymentRepository.Create(payment);
        }

        internal Task<List<Payment>> GetPayments()
        {
            return paymentRepository.GetList();
        }

        public Task<Payment?> GetPaymentById(Guid id)
        {
            return paymentRepository.GetById(id);
        }

        public Task<List<Payment>> GetPaymentsByUserId(Guid id)
        {
            return paymentRepository.GetByUserId(id);
        }

        public Task<List<Payment>> GetPaymentsByCampaignId(Guid id)
        {
            return paymentRepository.GetByCampaignId(id);
        }

        public Task<Payment> ConfirmPayment(Payment payment)
        {
            payment.PaymentStatus = PaymentStatus.Confirmed;

            var ret = paymentRepository.Update(payment);

            bus.Publish(new PaymentConfirmedMessage() { Value = payment.Value, PaymentId = payment.Id, CampaignId = payment.CampaignId });

            return ret;
        }
    }
}
