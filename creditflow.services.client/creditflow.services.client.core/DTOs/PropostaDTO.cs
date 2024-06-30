namespace creditflow.services.client.core.DTOs
{
    public class PropostaDTO
    {
        public Guid ClienteId { get; set; }
        public decimal ValorCredito { get; set; }
        public DateTime DataProposta { get; set; }
    }
}