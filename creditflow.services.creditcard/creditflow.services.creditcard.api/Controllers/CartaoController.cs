using creditflow.services.creditcard.application.InputModels;
using creditflow.services.creditcard.application.Services.Interfaces;
using creditflow.services.creditcard.application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace creditflow.services.creditcard.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ICartaoService _cartaoService;

        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter([FromQuery] Guid id)
        {
            CartaoViewModel cliente = await _cartaoService.ObterCartaoAsync(id);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            List<CartaoViewModel> cliente = await _cartaoService.ObterTodosOsCartoesAsync();
            return Ok(cliente);
        }

        [HttpGet("TodosPorCliente/{clienteId}")]
        public async Task<IActionResult> ObterTodosPorCliente([FromQuery] Guid clienteId)
        {
            List<CartaoViewModel> cliente = await _cartaoService.ObterTodosOsCartoesPorClienteAsync(clienteId);
            return Ok(cliente);
        }

        [HttpPut("Bloquear/{id}")]
        public async Task<IActionResult> Bloquear([FromQuery] Guid id)
        {
            CartaoViewModel cartao = await _cartaoService.BloquearCartaoAsync(id);
            return Ok(cartao);
        }
        
        [HttpPut("Expirar/{id}")]
        public async Task<IActionResult> Expirar([FromQuery] Guid id)
        {
            CartaoViewModel cartao = await _cartaoService.ExpirarCartaoAsync(id);
            return Ok(cartao);
        }
        
        [HttpPut]
        public async Task<IActionResult> AtualizarLimite([FromBody] AtualizarCartaoInputModel inputModel)
        {
            CartaoViewModel cartao = await _cartaoService.AtualizarLimiteDoCartaoAsync(inputModel);
            return Ok(cartao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover([FromBody] Guid id)
        {
            await _cartaoService.RemoverCartaoAsync(id);
            return Ok(id);
        }
    }
}