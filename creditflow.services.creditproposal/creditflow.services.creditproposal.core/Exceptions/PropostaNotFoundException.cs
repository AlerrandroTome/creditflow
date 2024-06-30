namespace creditflow.services.creditproposal.core.Exceptions
{
    public class PropostaNotFoundException : Exception
    {
        public PropostaNotFoundException() : base("A proposta não foi encontrado") { }
    }
}
