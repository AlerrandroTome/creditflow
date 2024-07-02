using creditflow.services.creditproposal.core.DTOs;

namespace creditflow.services.creditproposal.core.Interfaces
{
    public interface IClienteService
    {
        Task NotificarPropostaAceita(PropostaDTO proposta);
    }
}