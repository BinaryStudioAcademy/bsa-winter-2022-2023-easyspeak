using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.WebAPI.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasySpeak.Core.WebAPI.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public static void AddValidation(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewSampleDtoValidator>());
        }

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
