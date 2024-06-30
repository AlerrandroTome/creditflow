using creditflow.services.creditproposal.core.Enums;

namespace creditflow.services.creditproposal.core.Entities
{
    public class Proposta : BaseEntity
    {
        public Proposta(Guid clienteId, decimal valorCredito, EPropostaStatus status) 
            : base(Guid.NewGuid())
        {
            ClienteId = clienteId;
            ValorCredito = valorCredito;
            DataProposta = DateTime.Now;
            Status = status;
        }

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal ValorCredito { get; private set; }
        public DateTime DataProposta { get; private set; }
        public EPropostaStatus Status { get; private set; }

        public void AtualizarValor(decimal newValue)
        {
            ValorCredito = newValue;
            Status = EPropostaStatus.AguardandoAnalise;
        }

        public void Negar()
        {
            Status = EPropostaStatus.Negada;
        }

        public void Aceitar()
        {
            Status = EPropostaStatus.Aceita;
        }
    }
}