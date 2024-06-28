using creditflow.services.client.core.Entities;

namespace creditflow.services.client.core.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente project);
    }
}
