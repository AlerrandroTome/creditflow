using creditflow.services.creditcard.core.Entities;
using System.Linq.Expressions;

namespace creditflow.services.creditcard.core.Repositories
{
    public interface ICartaoRepository
    {
        Task AdicionarAsync(Cartao cartao);
        Task<Cartao?> ObterAsync(Expression<Func<Cartao, bool>> condiction, string[]? includes = null);
        Task<List<Cartao>> ObterTodosAsync();
        Task<List<Cartao>> ObterTodosAsync(Expression<Func<Cartao, bool>> condiction, string[]? includes = null);
        Task AtualizarAsync(Cartao cartao);
        Task RemoverAsync(Guid id);
    }
}
