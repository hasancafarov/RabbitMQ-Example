namespace RabbitMQ_Example.Service
{
    public interface IRabbitMQService
    {
        public void SendNametoQueue(string name);
    }
}
