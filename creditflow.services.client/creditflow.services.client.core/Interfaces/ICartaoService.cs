using creditflow.services.sharedtypes;

namespace creditflow.services.client.core.Interfaces
{
    public interface ICartaoService
    {
        Task SolicitarCartao(CartaoDTO cartao);
    }
}