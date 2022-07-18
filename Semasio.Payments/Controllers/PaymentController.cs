using Microsoft.AspNetCore.Mvc;
using Semasio.Payments.DataAccess.Models;
using Semasio.Payments.Services;

namespace Semasio.Payments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly PaymentService paymentService;

        public PaymentController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet()]
        public Task<List<Payment>> GetPayments()
        {
            return paymentService.GetPayments();
        }

        [HttpGet("{id}")]
        public Task<Payment?> GetPaymentById(Guid id)
        {
            return paymentService.GetPaymentById(id);
        }

        [HttpGet("Campaign/{id}")]
        public Task<List<Payment>> GetPaymentsByCampaignId(Guid id)
        {
            return paymentService.GetPaymentsByCampaignId(id);
        }

        [HttpGet("User/{id}")]
        public Task<List<Payment>> GetPaymentsByUserId(Guid id)
        {
            return paymentService.GetPaymentsByUserId(id);
        }

        [HttpPost]
        public Task<Payment> NewPayment(Payment payment)
        {
            return paymentService.InitiatePayment(payment);
        }

        [HttpPost("Callback")]
        public Task<Payment> PaymentCallback(Payment payment)
        {
            //TODO: Obviously we should certify that only payment provider is able to call this method
            return paymentService.ConfirmPayment(payment);
        }
    }
}
