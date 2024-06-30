using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.ViewModels;

namespace creditflow.services.creditproposal.application.Services.Interfaces
{
    public interface IPropostaService
    {
        Task<PropostaViewModel> CriarPropostaAsync(CriarPropostaInputModel inputModel);
        Task<PropostaViewModel> AtualizarValorDaPropostaAsync(AtualizarValorDePropostaInputModel inputModel);
        Task<PropostaViewModel> AceitarPropostaAsync(Guid popostaId);
        Task<PropostaViewModel> NegarPropostaAsync(Guid propostaId);
        Task<PropostaViewModel> ObterPropostaAsync(Guid id);
        Task<List<PropostaViewModel>> ObterTodasAsPropostasAsync();
        Task<List<PropostaViewModel>> ObterTodasAsPropostasPorClienteAsync(Guid clientId);
        Task<Guid> RemoverPropostaAsync(Guid id);
    }
}