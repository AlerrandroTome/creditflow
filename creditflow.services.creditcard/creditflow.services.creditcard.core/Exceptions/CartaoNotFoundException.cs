namespace creditflow.services.creditcard.core.Exceptions
{
    public class CartaoNotFoundException : Exception
    {
        public CartaoNotFoundException() : base("O cartão não foi encontrado") { }
    }
}
