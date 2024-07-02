using creditflow.services.creditproposal.core.Entities;
using System.Linq.Expressions;

namespace creditflow.services.creditproposal.core.Repositories
{
    public interface IPropostaRepository
    {
        Task CriarAsync(Proposta proposta);
        Task<Proposta?> ObterAsync(Expression<Func<Proposta, bool>> condiction, string[]? includes = null);
        Task<List<Proposta>> ObterTodosAsync();
        Task<List<Proposta>> ObterTodosAsync(Expression<Func<Proposta, bool>> condiction, string[]? includes = null);
        Task AtualizarAsync(Proposta proposta);
        Task RemoverAsync(Guid id);
    }
}