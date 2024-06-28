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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteInputModel inputModel)
        {
            ClienteViewModel cliente = await _clientService.CreateClientAsync(inputModel);
            return Created(nameof(Post), cliente);
        }
    }
}