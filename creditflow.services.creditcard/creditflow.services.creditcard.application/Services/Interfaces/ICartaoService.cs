using creditflow.services.creditcard.application.InputModels;
using creditflow.services.creditcard.application.ViewModels;

namespace creditflow.services.creditcard.application.Services.Interfaces
{
    public interface ICartaoService
    {
        Task<CartaoViewModel> CriarCartaoAsync(CriarCartaoInputModel inputModel);
        Task<CartaoViewModel> AtualizarLimiteDoCartaoAsync(AtualizarCartaoInputModel inputModel);
        Task<CartaoViewModel> ObterCartaoAsync(Guid id);
        Task<List<CartaoViewModel>> ObterTodosOsCartoesAsync();
        Task<List<CartaoViewModel>> ObterTodosOsCartoesPorClienteAsync(Guid clientId);
        Task<CartaoViewModel> ExpirarCartaoAsync(Guid cardId);
        Task<CartaoViewModel> BloquearCartaoAsync(Guid cardId);
        Task<Guid> RemoverCartaoAsync(Guid id);
    }
}