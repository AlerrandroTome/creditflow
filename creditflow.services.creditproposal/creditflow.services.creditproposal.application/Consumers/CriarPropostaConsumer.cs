using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.Services.Interfaces;
using creditflow.services.creditproposal.core.DTOs;
using MassTransit;

namespace creditflow.services.creditproposal.application.Consumers
{
    public class CriarPropostaConsumer : IConsumer<PropostaDTO>
    {
        private readonly IPropostaService _propostaService;

        public CriarPropostaConsumer(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        public async Task Consume(ConsumeContext<PropostaDTO> context)
        {
            PropostaDTO proposta = context.Message;
            CriarPropostaInputModel inputModel = new CriarPropostaInputModel(proposta.ClienteId, proposta.ValorCredito, proposta.DataProposta);
            await _propostaService.CriarPropostaAsync(inputModel);
        }
    }
}