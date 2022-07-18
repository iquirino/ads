using MassTransit;
using Semasio.Ads.Contracts;
using Semasio.Ads.Services;

namespace Semasio.Ads.Consumers
{
    public class PaymentConfirmedConsumer : IConsumer<PaymentConfirmedMessage>
    {
        readonly ILogger<PaymentConfirmedConsumer> _logger;

        readonly CampaignService _campaignService;

        public PaymentConfirmedConsumer(ILogger<PaymentConfirmedConsumer> logger, CampaignService campaignService)
        {
            _logger = logger;
            _campaignService = campaignService;
        }

        public async Task Consume(ConsumeContext<PaymentConfirmedMessage> context)
        {
            _logger.LogInformation($"Payment confirmed: {context.Message.PaymentId}");

            await _campaignService.ApplyPayment(context.Message.CampaignId, context.Message.Value);
        }
    }
}
