namespace creditflow.services.creditproposal.infrastructure.MessageBus
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CriarPropostaQueue { get; set; }
        public string CriarPropostaQueueDeadLetter { get; set; }
        public string NotificarPropostaAceitaQueue { get; set; }
    }
}
