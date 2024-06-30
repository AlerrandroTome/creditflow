namespace creditflow.services.creditproposal.core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string email, string telefone) : base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            DataCadastro = DateTime.Now;

            Propostas = new List<Proposta>();
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Proposta> Propostas { get; private set; }
    }
}
