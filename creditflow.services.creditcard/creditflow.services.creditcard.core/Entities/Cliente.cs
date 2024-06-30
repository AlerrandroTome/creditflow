namespace creditflow.services.creditcard.core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string email, string telefone) : base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            DataCadastro = DateTime.Now;

            Cartoes = new List<Cartao>();
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Cartao> Cartoes { get; private set; }
    }
}
