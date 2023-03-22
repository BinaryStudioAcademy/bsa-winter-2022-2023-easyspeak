using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.MappingProfiles;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.WebAPI.Validators;
using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ.Services;
using FirebaseAdmin;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;


namespace EasySpeak.Core.WebAPI.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<ILessonsService, LessonsService>();
            services.AddSingleton<IConnectionProvider>(_ => new ConnectionProvider(configuration.GetValue<string>("Rabbit")));
            services.AddTransient<IMessageProducer, MessageProducer>();
            services.AddScoped<IFirebaseAuthService, FirebaseAuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddFirebaseApp();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(LessonsProfile)));
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

        public static void AddFirebaseAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var projectId = configuration.GetSection("FirebaseConfig")
                .GetValue<string>("project_id");

            var secureUri = configuration.GetSection("FirebaseConfig")
                .GetValue<string>("secure_uri");


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"{secureUri}/{projectId}";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"{secureUri}/{projectId}",
                        ValidateAudience = true,
                        ValidAudience = projectId,
                        ValidateLifetime = true
                    };
                });
        }

        public static void AddFirebaseApp(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile($"{Environment.CurrentDirectory}/FirebaseServiceAccountKey.json")
            });
        }
    }
}
