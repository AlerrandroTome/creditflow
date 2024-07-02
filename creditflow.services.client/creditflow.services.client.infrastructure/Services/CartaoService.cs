using creditflow.services.client.core.Interfaces;
using creditflow.services.client.infrastructure.MessageBus;
using creditflow.services.sharedtypes;
using Microsoft.Extensions.Options;

namespace creditflow.services.client.infrastructure.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly IMessageBusService _messageBusService;
        private readonly string _queueName;

        public CartaoService(IMessageBusService messageBusService, IOptions<RabbitMQConfig> options)
        {
            _messageBusService = messageBusService;
            _queueName = options.Value.SolicitarCartaoQueue;
        }

        public async Task SolicitarCartao(CartaoDTO cartao)
        {
            await _messageBusService.Publish(_queueName, cartao);
        }
    }
}
