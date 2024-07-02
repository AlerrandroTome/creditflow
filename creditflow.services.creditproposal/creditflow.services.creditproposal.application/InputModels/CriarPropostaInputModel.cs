namespace creditflow.services.creditproposal.application.InputModels
{
    public class CriarPropostaInputModel
    {
        public CriarPropostaInputModel(Guid clienteId, decimal valorCredito, DateTime dataProposta)
        {
            ClienteId = clienteId;
            ValorCredito = valorCredito;
            DataProposta = dataProposta;
        }

        public Guid ClienteId { get; private set; }
        public decimal ValorCredito { get; private set; }
        public DateTime DataProposta { get; private set; }
    }
}
