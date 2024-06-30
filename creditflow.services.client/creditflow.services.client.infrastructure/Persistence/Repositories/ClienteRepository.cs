using creditflow.services.client.core.Entities;
using creditflow.services.client.core.Exceptions;
using creditflow.services.client.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace creditflow.services.client.infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CreditFlowDbContext _dbContext;

        public ClienteRepository(CreditFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriarAsync(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            Cliente? cliente = _dbContext.Clientes.AsNoTracking().Where(w => w.Id.Equals(id)).FirstOrDefault();
            
            if(cliente is null)
            {
                throw new ClienteNotFoundException();
            }

            _dbContext.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            return await _dbContext.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente?> ObterAsync(Expression<Func<Cliente, bool>> condiction, string[]? includes = null)
        {
            IQueryable<Cliente> query = _dbContext.Clientes.AsNoTracking().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _dbContext.Update(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}