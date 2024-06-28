using creditflow.services.client.application.InputModels;
using creditflow.services.client.application.ViewModels;

namespace creditflow.services.client.application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteViewModel> CreateClientAsync(CreateClienteInputModel inputModel);
    }
}
