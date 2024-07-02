using creditflow.services.client.core.Interfaces;
using creditflow.services.sharedtypes;
using MassTransit;

namespace creditflow.services.client.application.Consumers
{
    public class PropostaAceitaConsumer : IConsumer<PropostaDTO>
    {
        private readonly ICartaoService _cartaoService;

        public PropostaAceitaConsumer(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        public async Task Consume(ConsumeContext<PropostaDTO> context)
        {
            PropostaDTO proposta = context.Message;
            CartaoDTO cartao = new CartaoDTO(proposta.ClienteId, proposta.ValorCredito);
            await _cartaoService.SolicitarCartao(cartao);
        }
    }
}