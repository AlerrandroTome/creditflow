namespace creditflow.services.creditcard.infrastructure.Persistence.RabbitMQ
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SolicitarCartaoQueue { get; set; }
        public string SolicitarCartaoQueueDeadLetter { get; set; }
    }
}
