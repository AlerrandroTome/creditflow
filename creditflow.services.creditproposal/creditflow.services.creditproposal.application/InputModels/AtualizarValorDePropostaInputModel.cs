namespace creditflow.services.creditproposal.application.InputModels
{
    public class AtualizarValorDePropostaInputModel
    {
        public AtualizarValorDePropostaInputModel(Guid id, decimal valorCredito)
        {
            Id = id;
            ValorCredito = valorCredito;
        }

        public Guid Id { get; private set; }
        public decimal ValorCredito { get; private set; }
    }
}
