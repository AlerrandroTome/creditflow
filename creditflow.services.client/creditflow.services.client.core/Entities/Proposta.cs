namespace creditflow.services.client.core.Entities
{
    public class Proposta : BaseEntity
    {
        public Proposta(Guid clienteId, decimal valorCredito, DateTime dataProposta, string status) 
            : base(Guid.NewGuid())
        {
            ClienteId = clienteId;
            ValorCredito = valorCredito;
            DataProposta = dataProposta;
            Status = status;
        }

        public Guid ClienteId { get; private set; }
        public decimal ValorCredito { get; private set; }
        public DateTime DataProposta { get; private set; }
        public string Status { get; private set; }
    }
}