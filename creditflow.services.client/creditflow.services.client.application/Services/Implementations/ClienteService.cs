using creditflow.services.client.application.InputModels;
using creditflow.services.client.application.Services.Interfaces;
using creditflow.services.client.application.ViewModels;
using creditflow.services.client.core.Entities;
using creditflow.services.client.core.Exceptions;
using creditflow.services.client.core.Repositories;

namespace creditflow.services.client.application.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clientRepository;

        public ClienteService(IClienteRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClienteViewModel> CriarClienteAsync(CreateClienteInputModel inputModel)
        {
            Cliente cliente = new Cliente(inputModel.Nome, inputModel.Email, inputModel.Telefone);
            await _clientRepository.CriarAsync(cliente);
            // Enviar para fila do Rabbit

            return new ClienteViewModel(cliente);
        }

        public async Task<List<ClienteViewModel>> ObterTodosOsClienteAsync()
        {
            List<Cliente> clientes = await _clientRepository.ObterTodosAsync();
            
            if(!clientes.Any())
            {
                return new List<ClienteViewModel>();
            }

            return clientes.Select(c => new ClienteViewModel(c)).ToList();
        }

        public async Task<ClienteViewModel> ObterClienteAsync(Guid id)
        {
            Cliente? cliente = await _clientRepository.ObterAsync(c => c.Id == id);
            
            if(cliente is null)
            {
                throw new ClienteNotFoundException();
            }

            return new ClienteViewModel(cliente);
        }

        public async Task<Guid> RemoverClienteAsync(Guid id)
        {
            await _clientRepository.RemoverAsync(id);
            return id;
        }

        public async Task<ClienteViewModel> AtualizarClienteAsync(UpdateClienteInputModel inputModel)
        {
            Cliente? cliente = await _clientRepository.ObterAsync(c => c.Id.Equals(inputModel.Id));

            if(cliente is null)
            {
                throw new ClienteNotFoundException();
            }

            cliente.Update(inputModel.Nome, inputModel.Email, inputModel.Telefone);
            await _clientRepository.AtualizarAsync(cliente);
            return new ClienteViewModel(cliente);
        }
    }
}