namespace creditflow.services.creditcard.application.InputModels
{
    public class CriarCartaoInputModel
    {
        public CriarCartaoInputModel(Guid clienteId, decimal totalCredito)
        {
            ClienteId = clienteId;
            TotalCredito = totalCredito;
        }

        public Guid ClienteId { get; private set; }
        public decimal TotalCredito { get; private set; }
    }
}