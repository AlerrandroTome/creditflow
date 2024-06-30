using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.Services.Interfaces;
using creditflow.services.creditproposal.application.ViewModels;
using creditflow.services.creditproposal.core.Entities;
using creditflow.services.creditproposal.core.Exceptions;
using creditflow.services.creditproposal.core.Repositories;
using creditflow.services.creditproposal.core.Enums;

namespace creditflow.services.creditproposal.application.Services.Implementations
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaService(IPropostaRepository clienteRepository)
        {
            _propostaRepository = clienteRepository;
        }

        public async Task<PropostaViewModel> CriarPropostaAsync(CriarPropostaInputModel inputModel)
        {
            Proposta proposta = new Proposta(inputModel.ClienteId, inputModel.ValorCredito, EPropostaStatus.AguardandoAnalise);
            await _propostaRepository.RemoverAsync(proposta);

            return new PropostaViewModel(proposta);
        }

        public async Task<List<PropostaViewModel>> ObterTodasAsPropostasPorClienteAsync(Guid clientId)
        {
            List<Proposta> propostas = await _propostaRepository.ObterTodosAsync(p => p.ClienteId.Equals(clientId));

            if (!propostas.Any())
            {
                return new List<PropostaViewModel>();
            }

            return propostas.Select(p => new PropostaViewModel(p)).ToList();
        }

        public async Task<List<PropostaViewModel>> ObterTodasAsPropostasAsync()
        {
            List<Proposta> propostas = await _propostaRepository.ObterTodosAsync();

            if (!propostas.Any())
            {
                return new List<PropostaViewModel>();
            }

            return propostas.Select(p => new PropostaViewModel(p)).ToList();
        }

        public async Task<PropostaViewModel> ObterPropostaAsync(Guid id)
        {
            Proposta? proposta = await _propostaRepository.ObterAsync(c => c.Id == id);

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }

            return new PropostaViewModel(proposta);
        }

        public async Task<Guid> RemoverPropostaAsync(Guid id)
        {
            await _propostaRepository.DeleteAsync(id);
            return id;
        }

        public async Task<PropostaViewModel> AtualizarValorDaPropostaAsync(AtualizarValorDePropostaInputModel inputModel)
        {
            Proposta? proposta = await _propostaRepository.ObterAsync(c => c.Id.Equals(inputModel.Id));

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }

            proposta.AtualizarValor(inputModel.ValorCredito);
            await _propostaRepository.UpdateAsync(proposta);
            return new PropostaViewModel(proposta);
        }

        public async Task<PropostaViewModel> AceitarPropostaAsync(Guid propostaId)
        {
            Proposta? proposta = await _propostaRepository.ObterAsync(c => c.Id.Equals(propostaId));

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }

            proposta.Aceitar();
            await _propostaRepository.UpdateAsync(proposta);

            // Enviar mensagem para o service de cliente

            return new PropostaViewModel(proposta);
        }

        public async Task<PropostaViewModel> NegarPropostaAsync(Guid propostaId)
        {
            Proposta? proposta = await _propostaRepository.ObterAsync(c => c.Id.Equals(propostaId));

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }

            proposta.Negar();
            await _propostaRepository.UpdateAsync(proposta);
            return new PropostaViewModel(proposta);
        }
    }
}