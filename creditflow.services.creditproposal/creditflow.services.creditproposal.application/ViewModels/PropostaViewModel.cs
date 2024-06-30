using creditflow.services.creditproposal.core.Entities;
using creditflow.services.creditproposal.core.Enums;

namespace creditflow.services.creditproposal.application.ViewModels
{
    public class PropostaViewModel
    {
        public PropostaViewModel(Proposta proposta)
        {
            ClienteId = proposta.ClienteId;
            ValorCredito = proposta.ValorCredito;
            DataProposta = proposta.DataProposta;
            Status = proposta.Status;
        }

        public Guid ClienteId { get; private set; }
        public decimal ValorCredito { get; private set; }
        public DateTime DataProposta { get; private set; }
        public EPropostaStatus Status { get; private set; }
    }
}