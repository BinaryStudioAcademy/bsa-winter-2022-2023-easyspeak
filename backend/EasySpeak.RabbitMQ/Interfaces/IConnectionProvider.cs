using RabbitMQ.Client;

namespace EasySpeak.RabbitMQ.Interfaces;

public interface IConnectionProvider
{
    public IConnection? Connection { get; }
}
