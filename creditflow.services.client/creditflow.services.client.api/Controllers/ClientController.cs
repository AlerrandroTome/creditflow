using creditflow.services.client.application.InputModels;
using creditflow.services.client.application.Services.Interfaces;
using creditflow.services.client.application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace creditflow.services.client.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteService _clientService;

        public ClientController(IClienteService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter([FromQuery] Guid id)
        {
            ClienteViewModel cliente = await _clientService.ObterClienteAsync(id);
            return Ok(cliente);
        }        
        
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            List<ClienteViewModel> cliente = await _clientService.ObterTodosOsClienteAsync();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateClienteInputModel inputModel)
        {
            ClienteViewModel cliente = await _clientService.CriarClienteAsync(inputModel);
            return Created(nameof(Criar), cliente);
        }        
        
        [HttpPut]
        public async Task<IActionResult> Remover([FromBody] UpdateClienteInputModel inputModel)
        {
            ClienteViewModel cliente = await _clientService.AtualizarClienteAsync(inputModel);
            return Ok(cliente);
        }        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            await _clientService.RemoverClienteAsync(id);
            return Ok(id);
        }
    }
}