using EasySpeak.Core.Common.Options;
using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ.Services;
using EasySpeak.RS.WebAPI.Interfaces;
using EasySpeak.RS.WebAPI.Options;
using EasySpeak.RS.WebAPI.Services;
using Neo4j.Driver;

namespace EasySpeak.RS.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCustomServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var serviceOption = configuration.GetSection("Neo4jSettings").Get<RecommendationServiceOptions>();
        var hostname = configuration.GetValue<string>("Rabbit");
        
        services.AddSingleton<IConnectionProvider>(_ => new ConnectionProvider(hostname));
        services.Configure<RabbitQueuesOptions>(configuration.GetSection("RabbitQueues"));
        services.AddTransient<IMessageConsumer, MessageConsumer>();

        services.Configure<RecommendationServiceOptions>(configuration.GetSection("Neo4jSettings"));
        services.AddSingleton(GraphDatabase.Driver(serviceOption.Connection,
            AuthTokens.Basic(serviceOption.User,
                serviceOption.Password)));

        services.AddTransient<IRecommendationService, RecommendationService>();
        services.AddTransient<IDataAccessService, DataAccessService>();
    }
}