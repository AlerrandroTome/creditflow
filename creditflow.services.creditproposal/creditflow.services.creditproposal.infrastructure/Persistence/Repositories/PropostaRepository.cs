using creditflow.services.creditproposal.core.Entities;
using creditflow.services.creditproposal.core.Exceptions;
using creditflow.services.creditproposal.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace creditflow.services.creditproposal.infrastructure.Persistence.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly CreditFlowDbContext _dbContext;

        public PropostaRepository(CreditFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriarAsync(Proposta proposta)
        {
            await _dbContext.Propostas.AddAsync(proposta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            Proposta? proposta = await _dbContext.Propostas.AsNoTracking().Where(w => w.Id.Equals(id)).FirstOrDefaultAsync();

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }

            _dbContext.Remove(proposta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Proposta>> ObterTodosAsync()
        {
            return await _dbContext.Propostas.AsNoTracking().ToListAsync();
        }

        public async Task<List<Proposta>> ObterTodosAsync(Expression<Func<Proposta, bool>> condiction, string[]? includes = null)
        {
            IQueryable<Proposta> query = _dbContext.Propostas.AsNoTracking().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<Proposta?> ObterAsync(Expression<Func<Proposta, bool>> condiction, string[]? includes = null)
        {
            IQueryable<Proposta> query = _dbContext.Propostas.AsNoTracking().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AtualizarAsync(Proposta proposta)
        {
            _dbContext.Update(proposta);
            await _dbContext.SaveChangesAsync();
        }
    }
}