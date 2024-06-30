using creditflow.services.creditcard.application.InputModels;
using creditflow.services.creditcard.application.Services.Interfaces;
using creditflow.services.creditcard.application.ViewModels;
using creditflow.services.creditcard.core.Entities;
using creditflow.services.creditcard.core.Exceptions;
using creditflow.services.creditcard.core.Repositories;

namespace creditflow.services.creditcard.application.Services.Implementations
{
    public class CartaoService : ICartaoService
    {
        private readonly ICartaoRepository _cartaoRepository;

        public CartaoService(ICartaoRepository cartaoRepository)
        {
            _cartaoRepository = cartaoRepository;
        }

        public async Task<CartaoViewModel> CriarCartaoAsync(CriarCartaoInputModel inputModel)
        {
            Cartao cartao = new Cartao(inputModel.ClienteId, inputModel.TotalCredito);
            await _cartaoRepository.AdicionarAsync(cartao);

            return new CartaoViewModel(cartao);
        }

        public async Task<CartaoViewModel> AtualizarLimiteDoCartaoAsync(AtualizarCartaoInputModel inputModel)
        {
            Cartao? cartao = await _cartaoRepository.ObterAsync(c => c.Id.Equals(inputModel.Id));

            if (cartao is null)
            {
                throw new CartaoNotFoundException();
            }

            cartao.AtualizarLimite(inputModel.TotalCredito);
            await _cartaoRepository.AtualizarAsync(cartao);
            return new CartaoViewModel(cartao);
        }

        public async Task<CartaoViewModel> ExpirarCartaoAsync(Guid cardId)
        {
            Cartao? cartao = await _cartaoRepository.ObterAsync(c => c.Id.Equals(cardId));

            if (cartao is null)
            {
                throw new CartaoNotFoundException();
            }

            cartao.ExpirarCartao();
            await _cartaoRepository.AtualizarAsync(cartao);
            return new CartaoViewModel(cartao);
        }

        public async Task<CartaoViewModel> BloquearCartaoAsync(Guid cardId)
        {
            Cartao? cartao = await _cartaoRepository.ObterAsync(c => c.Id.Equals(cardId));

            if (cartao is null)
            {
                throw new CartaoNotFoundException();
            }

            cartao.BloquearCartao();
            await _cartaoRepository.AtualizarAsync(cartao);
            return new CartaoViewModel(cartao);
        }

        public async Task<CartaoViewModel> ObterCartaoAsync(Guid id)
        {
            Cartao? cartao = await _cartaoRepository.ObterAsync(c => c.Id == id);

            if (cartao is null)
            {
                throw new CartaoNotFoundException();
            }

            return new CartaoViewModel(cartao);
        }

        public async Task<List<CartaoViewModel>> ObterTodosOsCartoesAsync()
        {
            List<Cartao> cartao = await _cartaoRepository.ObterTodosAsync();

            if (!cartao.Any())
            {
                return new List<CartaoViewModel>();
            }

            return cartao.Select(p => new CartaoViewModel(p)).ToList();
        }

        public async Task<List<CartaoViewModel>> ObterTodosOsCartoesPorClienteAsync(Guid clientId)
        {
            List<Cartao> cartoes = await _cartaoRepository.ObterTodosAsync(p => p.ClienteId.Equals(clientId));

            if (!cartoes.Any())
            {
                return new List<CartaoViewModel>();
            }

            return cartoes.Select(p => new CartaoViewModel(p)).ToList();
        }

        public async Task<Guid> RemoverCartaoAsync(Guid id)
        {
            await _cartaoRepository.RemoverAsync(id);
            return id;
        }
    }
}