using creditflow.services.creditcard.core.Entities;
using creditflow.services.creditcard.core.Enums;

namespace creditflow.services.creditcard.application.ViewModels
{
    public class CartaoViewModel
    {
        public CartaoViewModel(Cartao cartao)
        {
            Id = cartao.Id;
            ClienteId = cartao.ClienteId;
            NumeroCartao = cartao.NumeroCartao;
            TotalCredito = cartao.TotalCredito;
            DataEmissao = cartao.DataEmissao;
            DataValidade = cartao.DataValidade;
            Status = cartao.Status;
        }

        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public string NumeroCartao { get; private set; }
        public decimal TotalCredito { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public ECartaoStatus Status { get; private set; }
    }
}