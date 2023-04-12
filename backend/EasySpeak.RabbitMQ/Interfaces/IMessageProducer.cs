namespace EasySpeak.RabbitMQ.Interfaces;

public interface IMessageProducer
{
    void Init(string queue, string exchange);
    void SendMessage<T>(T message);
}
