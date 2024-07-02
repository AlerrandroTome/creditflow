using creditflow.services.client.core.DTOs;
using creditflow.services.client.core.Interfaces;
using creditflow.services.client.infrastructure.MessageBus;
using Microsoft.Extensions.Options;

namespace creditflow.services.client.infrastructure.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IMessageBusService _messageBusService;
        private readonly string _queueName;

        public PropostaService(IMessageBusService messageBusService, IOptions<RabbitMQConfig> options)
        {
            _messageBusService = messageBusService;
            _queueName = options.Value.CriarPropostaQueue;
        }

        public async Task CriarProposta(PropostaDTO proposta)
        {
            await _messageBusService.Publish(_queueName, proposta);
        }
    }
}