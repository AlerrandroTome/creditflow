using AutoMapper;
using creditflow.services.client.application.InputModels;
using creditflow.services.client.application.Services.Interfaces;
using creditflow.services.client.application.ViewModels;
using creditflow.services.client.core.Entities;
using creditflow.services.client.core.Repositories;

namespace creditflow.services.client.application.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClienteViewModel> CreateClientAsync(CreateClienteInputModel inputModel)
        {
            Cliente cliente = new Cliente(inputModel.Nome, inputModel.Email, inputModel.Telefone);
            await _clientRepository.AddAsync(cliente);
            // Enviar para fila do Rabbit

            return _mapper.Map<ClienteViewModel>(cliente);
        }
    }
}