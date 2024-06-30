using creditflow.services.creditcard.core.Enums;

namespace creditflow.services.creditcard.application.InputModels
{
    public class AtualizarCartaoInputModel
    {
        public AtualizarCartaoInputModel(Guid id, decimal totalCredito)
        {
            Id = id;
            TotalCredito = totalCredito;
        }

        public Guid Id { get; private set; }
        public decimal TotalCredito { get; private set; }
    }
}
