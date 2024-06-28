namespace creditflow.services.client.core.Entities
{
    public class Proposta : BaseEntity
    {
        public Proposta()
        {
            Id = Guid.NewGuid();
            DataProposta = DateTime.Now;
        }

        public Guid ClienteId { get; set; }
        public decimal ValorCredito { get; set; }
        public DateTime DataProposta { get; set; }
        public string Status { get; set; }
    }
}