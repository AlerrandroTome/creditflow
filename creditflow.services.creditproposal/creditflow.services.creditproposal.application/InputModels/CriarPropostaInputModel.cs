namespace creditflow.services.creditproposal.application.InputModels
{
    public class CriarPropostaInputModel
    {
        public CriarPropostaInputModel(Guid clienteId, decimal valorCredito)
        {
            ClienteId = clienteId;
            ValorCredito = valorCredito;
        }

        public Guid ClienteId { get; private set; }
        public decimal ValorCredito { get; private set; }
    }
}
