namespace creditflow.services.client.infrastructure.MessageBus
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CriarPropostaQueue { get; set; }
        public string SolicitarCartaoQueue { get; set; }
        public string NotificarPropostaAceitaQueue { get; set; }
        public string NotificarPropostaAceitaQueueDeadLetter { get; set; }
    }
}
