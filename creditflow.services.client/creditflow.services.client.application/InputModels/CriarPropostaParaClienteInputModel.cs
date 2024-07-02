namespace creditflow.services.client.application.InputModels
{
    public class CriarPropostaParaClienteInputModel
    {
        public CriarPropostaParaClienteInputModel(Guid clientId, decimal valorCredito)
        {
            ClientId = clientId;
            ValorCredito = valorCredito;
        }

        public Guid ClientId { get; set; }
        public decimal ValorCredito { get; set; }
    }
}
