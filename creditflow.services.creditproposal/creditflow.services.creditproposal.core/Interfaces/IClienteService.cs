using creditflow.services.sharedtypes;

namespace creditflow.services.creditproposal.core.Interfaces
{
    public interface IClienteService
    {
        Task NotificarPropostaAceita(PropostaDTO proposta);
    }
}