namespace creditflow.services.client.application.InputModels
{
    public class UpdateClienteInputModel
    {
        public UpdateClienteInputModel(Guid id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
