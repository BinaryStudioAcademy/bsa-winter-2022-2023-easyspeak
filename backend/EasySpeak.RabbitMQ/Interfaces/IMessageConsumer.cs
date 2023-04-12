namespace EasySpeak.RabbitMQ.Interfaces;

public interface IMessageConsumer
{
    void Init(string queue);
    void Receive<T>(Action<T?> onMessage);
}
