namespace creditflow.services.client.core.DTOs
{
    public class CartaoDTO
    {
        public CartaoDTO(Guid clienteId, decimal totalCredito)
        {
            ClienteId = clienteId;
            TotalCredito = totalCredito;
        }

        public Guid ClienteId { get; set; }
        public decimal TotalCredito { get; set; }
    }
}