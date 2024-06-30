using creditflow.services.client.core.Entities;
using System.Linq.Expressions;

namespace creditflow.services.client.core.Repositories
{
    public interface IClienteRepository
    {
        Task CriarAsync(Cliente project);
        Task<Cliente?> ObterAsync(Expression<Func<Cliente, bool>> condiction, string[]? includes = null);
        Task<List<Cliente>> ObterTodosAsync();
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(Guid id);
    }
}
