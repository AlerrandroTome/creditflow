namespace creditflow.services.client.core.DTOs
{
    public class PropostaDTO
    {
        public bool Atualizacao { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorCredito { get; set; }
        public DateTime DataProposta { get; set; }
    }
}