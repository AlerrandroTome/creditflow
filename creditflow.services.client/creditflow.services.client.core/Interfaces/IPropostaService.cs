using creditflow.services.client.core.DTOs;

namespace creditflow.services.client.core.Interfaces
{
    public interface IPropostaService
    {
        Task CriarProposta(PropostaDTO proposta);
    }
}
