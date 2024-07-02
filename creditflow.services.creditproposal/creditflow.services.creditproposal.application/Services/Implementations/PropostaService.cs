using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.Services.Interfaces;
using creditflow.services.creditproposal.application.ViewModels;
using creditflow.services.creditproposal.core.Entities;
using creditflow.services.creditproposal.core.Exceptions;
using creditflow.services.creditproposal.core.Repositories;
using creditflow.services.creditproposal.core.Enums;
using creditflow.services.creditproposal.core.Interfaces;
using creditflow.services.sharedtypes;

namespace creditflow.services.creditproposal.application.Services.Implementations
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly IClienteService _clienteService;

        public PropostaService(IPropostaRepository clienteRepository, IClienteService clienteService)
        {
            _propostaRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public async Task<PropostaViewModel> CriarPropostaAsync(CriarPropostaInputModel inputModel)
        {
            Proposta proposta = new Proposta(inputModel.ClienteId, inputModel.ValorCredito, EPropostaStatus.AguardandoAnalise, inputModel.DataProposta);
            await _propostaRepository.CriarAsync(proposta);

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
            await _propostaRepository.RemoverAsync(id);
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
            await _propostaRepository.AtualizarAsync(proposta);
            return new PropostaViewModel(proposta);
        }

        public async Task<PropostaViewModel> AceitarPropostaAsync(Guid propostaId)
        {
            Proposta? proposta = await _propostaRepository.ObterAsync(c => c.Id.Equals(propostaId));

            if (proposta is null)
            {
                throw new PropostaNotFoundException();
            }


            PropostaDTO propostaDto = new PropostaDTO(proposta.ClienteId, proposta.ValorCredito, proposta.DataProposta);
            await _clienteService.NotificarPropostaAceita(propostaDto);

            proposta.Aceitar();
            await _propostaRepository.AtualizarAsync(proposta);

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
            await _propostaRepository.AtualizarAsync(proposta);
            return new PropostaViewModel(proposta);
        }
    }
}