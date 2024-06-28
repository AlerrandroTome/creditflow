namespace creditflow.services.client.core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;

            Propostas = new List<Proposta>();
            Cartoes = new List<Cartao>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Proposta> Propostas { get; set; }
        public List<Cartao> Cartoes { get; set; }
    }
}
