using creditflow.services.client.core.DTOs;

namespace creditflow.services.client.core.Interfaces
{
    public interface ICartaoService
    {
        Task SolicitarCartao(CartaoDTO cartao);
    }
}