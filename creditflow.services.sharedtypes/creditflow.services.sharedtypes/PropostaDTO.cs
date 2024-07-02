namespace creditflow.services.sharedtypes
{
    public class PropostaDTO
    {
        public PropostaDTO(Guid clienteId, decimal valorCredito, DateTime dataProposta)
        {
            ClienteId = clienteId;
            ValorCredito = valorCredito;
            DataProposta = dataProposta;
        }

        public Guid ClienteId { get; set; }
        public decimal ValorCredito { get; set; }
        public DateTime DataProposta { get; set; }
    }
}