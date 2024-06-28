namespace creditflow.services.client.application.InputModels
{
    public class CreateClienteInputModel
    {
        public CreateClienteInputModel(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public decimal ValorCredito { get; set; }
    }
}
