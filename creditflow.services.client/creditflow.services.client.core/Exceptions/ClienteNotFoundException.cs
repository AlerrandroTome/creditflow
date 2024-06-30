namespace creditflow.services.client.core.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException() : base("O cliente não foi encontrado") { }
    }
}
