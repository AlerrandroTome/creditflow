using creditflow.services.creditproposal.application.InputModels;
using creditflow.services.creditproposal.application.Services.Interfaces;
using creditflow.services.creditproposal.application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace creditflow.services.creditproposal.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService)
        {
            this._propostaService = propostaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter([FromQuery] Guid id)
        {
            PropostaViewModel cliente = await _propostaService.ObterPropostaAsync(id);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            List<PropostaViewModel> cliente = await _propostaService.ObterTodasAsPropostasAsync();
            return Ok(cliente);
        }

        [HttpGet("TodosPorCliente/{clienteId}")]
        public async Task<IActionResult> ObterTodosPorCliente([FromQuery] Guid clienteId)
        {
            List<PropostaViewModel> cliente = await _propostaService.ObterTodasAsPropostasPorClienteAsync(clienteId);
            return Ok(cliente);
        }

        [HttpPut("Negar/{id}")]
        public async Task<IActionResult> Bloquear([FromQuery] Guid id)
        {
            PropostaViewModel cartao = await _propostaService.NegarPropostaAsync(id);
            return Ok(cartao);
        }

        [HttpPut("Aceitar/{id}")]
        public async Task<IActionResult> Expirar([FromQuery] Guid id)
        {
            PropostaViewModel cartao = await _propostaService.AceitarPropostaAsync(id);
            return Ok(cartao);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarLimite([FromBody] AtualizarValorDePropostaInputModel inputModel)
        {
            PropostaViewModel cartao = await _propostaService.AtualizarValorDaPropostaAsync(inputModel);
            return Ok(cartao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover([FromBody] Guid id)
        {
            await _propostaService.RemoverPropostaAsync(id);
            return Ok(id);
        }
    }
}