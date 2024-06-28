namespace creditflow.services.client.core.Entities
{
    public class Cartao : BaseEntity
    {
        public Cartao()
        {
            Id = Guid.NewGuid();
            DataEmissao = DateTime.Now;
            // Todo cartão terá a validade de 10 anos
            DataValidade = DateTime.Now.AddYears(10);
        }

        public Guid ClienteId { get; set; }
        public string NumeroCartao { get; set; }
        public decimal TotalCredito { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Status { get; set; }
    }
}
