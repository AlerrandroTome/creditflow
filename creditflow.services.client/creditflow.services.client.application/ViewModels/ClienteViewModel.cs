namespace creditflow.services.client.application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}