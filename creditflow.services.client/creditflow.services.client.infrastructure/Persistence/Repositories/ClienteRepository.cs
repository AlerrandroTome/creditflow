using creditflow.services.client.core.Entities;
using creditflow.services.client.core.Repositories;

namespace creditflow.services.client.infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CreditFlowDbContext _dbContext;

        public ClienteRepository(CreditFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}
