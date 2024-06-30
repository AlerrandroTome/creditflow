using creditflow.services.client.core.Entities;

namespace creditflow.services.client.application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            DataCadastro = cliente.DataCadastro;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}