using creditflow.services.sharedtypes;
using creditflow.services.creditproposal.core.Interfaces;
using creditflow.services.creditproposal.infrastructure.MessageBus;
using Microsoft.Extensions.Options;

namespace creditflow.services.creditproposal.infrastructure.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMessageBusService _messageBusService;
        private readonly string _queueName;

        public ClienteService(IMessageBusService messageBusService, IOptions<RabbitMQConfig> options)
        {
            _messageBusService = messageBusService;
            _queueName = options.Value.NotificarPropostaAceitaQueue;
        }

        public async Task NotificarPropostaAceita(PropostaDTO proposta)
        {
            await _messageBusService.Publish(_queueName, proposta);
        }
    }
}
