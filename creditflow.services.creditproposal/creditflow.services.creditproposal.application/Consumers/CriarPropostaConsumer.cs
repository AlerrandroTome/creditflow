using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.Services.Interfaces;
using creditflow.services.sharedtypes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace creditflow.services.creditproposal.application.Consumers
{
    public class CriarPropostaConsumer : IConsumer<PropostaDTO>
    {
        private readonly IServiceProvider _serviceProvider;

        public CriarPropostaConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<PropostaDTO> context)
        {
            PropostaDTO proposta = context.Message;
            CriarPropostaInputModel inputModel = new CriarPropostaInputModel(proposta.ClienteId, proposta.ValorCredito, proposta.DataProposta);
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IPropostaService service = scope.ServiceProvider.GetRequiredService<IPropostaService>();
                await service.CriarPropostaAsync(inputModel);
            }
        }
    }
}