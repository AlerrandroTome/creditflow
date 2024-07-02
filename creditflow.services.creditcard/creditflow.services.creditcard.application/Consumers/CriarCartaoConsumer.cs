using creditflow.services.creditcard.application.InputModels;
using creditflow.services.creditcard.application.Services.Interfaces;
using creditflow.services.sharedtypes;
using MassTransit;

namespace creditflow.services.creditcard.application.Consumers
{
    public class CriarCartaoConsumer : IConsumer<CartaoDTO>
    {
        private readonly ICartaoService _cartaoService;

        public CriarCartaoConsumer(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        public async Task Consume(ConsumeContext<CartaoDTO> context)
        {
            CartaoDTO cartaoDto = context.Message;
            CriarCartaoInputModel inputModel = new CriarCartaoInputModel(cartaoDto.ClienteId, cartaoDto.TotalCredito);

            await _cartaoService.CriarCartaoAsync(inputModel);
        }
    }
}