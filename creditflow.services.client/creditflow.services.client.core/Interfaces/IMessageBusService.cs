namespace creditflow.services.client.core.Interfaces
{
    public interface IMessageBusService
    {
        Task Publish<T>(string queue, T message) where T : class;
    }
}
