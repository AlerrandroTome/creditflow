namespace creditflow.services.client.core.Entities
{
    public class Cartao : BaseEntity
    {
        public Cartao(Guid clienteId, string numeroCartao, decimal totalCredito, DateTime dataEmissao, DateTime dataValidade, string status) : base(Guid.NewGuid())
        {
            ClienteId = clienteId;
            NumeroCartao = numeroCartao;
            TotalCredito = totalCredito;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
            Status = status;

            DataEmissao = DateTime.Now;
            // Todo cartão terá a validade de 10 anos
            DataValidade = DateTime.Now.AddYears(10);
        }

        public Guid ClienteId { get; private set; }
        public string NumeroCartao { get; private set; }
        public decimal TotalCredito { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public string Status { get; private set; }
    }
}
