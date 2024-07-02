using creditflow.services.client.core.Interfaces;
using MassTransit;

namespace creditflow.services.client.infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public MessageBusService(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Publish<T>(string queue, T message) where T : class
        {
            ISendEndpoint sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queue}"));
            await sendEndpoint.Send(message);
        }
    }
}