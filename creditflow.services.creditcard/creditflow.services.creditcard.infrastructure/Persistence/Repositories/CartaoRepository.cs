using creditflow.services.creditcard.core.Entities;
using creditflow.services.creditcard.core.Exceptions;
using creditflow.services.creditcard.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace creditflow.services.creditcard.infrastructure.Persistence.Repositories
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly CreditFlowDbContext _dbContext;

        public CartaoRepository(CreditFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(Cartao Cartao)
        {
            await _dbContext.Cartoes.AddAsync(Cartao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            Cartao? Cartao = _dbContext.Cartoes.AsNoTracking().Where(w => w.Id.Equals(id)).FirstOrDefault();
            
            if(Cartao is null)
            {
                throw new CartaoNotFoundException();
            }

            _dbContext.Remove(Cartao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Cartao>> ObterTodosAsync()
        {
            return await _dbContext.Cartoes.AsNoTracking().ToListAsync();
        }

        public async Task<List<Cartao>> ObterTodosAsync(Expression<Func<Cartao, bool>> condiction, string[]? includes = null)
        {
            IQueryable<Cartao> query = _dbContext.Cartoes.AsNoTracking().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<Cartao?> ObterAsync(Expression<Func<Cartao, bool>> condiction, string[]? includes = null)
        {
            IQueryable<Cartao> query = _dbContext.Cartoes.AsNoTracking().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AtualizarAsync(Cartao Cartao)
        {
            _dbContext.Update(Cartao);
            await _dbContext.SaveChangesAsync();
        }
    }
}