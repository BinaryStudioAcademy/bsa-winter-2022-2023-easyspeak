using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Communicator.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEasySpeakCoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("EasySpeakCoreDBConnection");
            services.AddDbContext<EasySpeakCoreContext>(options =>
                options.UseSqlServer(
                    connectionsString,
                    opt => opt.MigrationsAssembly(typeof(EasySpeakCoreContext).Assembly.GetName().Name)));
        }
    }
}
