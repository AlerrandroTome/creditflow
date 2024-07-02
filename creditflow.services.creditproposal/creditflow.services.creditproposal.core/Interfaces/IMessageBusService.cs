namespace creditflow.services.creditproposal.core.Interfaces
{
    public interface IMessageBusService
    {
        Task Publish<T>(string queue, T message) where T : class;
    }
}
