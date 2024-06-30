using creditflow.services.client.application.InputModels;
using creditflow.services.client.application.ViewModels;

namespace creditflow.services.client.application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteViewModel> CriarClienteAsync(CreateClienteInputModel inputModel);
        Task<ClienteViewModel> AtualizarClienteAsync(UpdateClienteInputModel inputModel);
        Task<ClienteViewModel> ObterClienteAsync(Guid id);
        Task<List<ClienteViewModel>> ObterTodosOsClienteAsync();
        Task<Guid> RemoverClienteAsync(Guid id);
    }
}
