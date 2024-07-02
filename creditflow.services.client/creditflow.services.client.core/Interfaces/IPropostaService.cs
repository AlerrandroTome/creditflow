using creditflow.services.sharedtypes;

namespace creditflow.services.client.core.Interfaces
{
    public interface IPropostaService
    {
        Task CriarProposta(PropostaDTO proposta);
    }
}
