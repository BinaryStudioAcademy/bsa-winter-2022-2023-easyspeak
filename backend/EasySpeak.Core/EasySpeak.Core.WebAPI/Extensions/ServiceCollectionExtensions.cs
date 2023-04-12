using System.Reflection;
using Azure.Storage.Blobs;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.MappingProfiles;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.Common.Options;
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

namespace EasySpeak.Core.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<ILessonsService, LessonsService>();
            services.AddTransient<IZoomApiService, ZoomApiService>();
            services.AddScoped<IFriendService, FriendService>();
            services.AddSingleton<IConnectionProvider>(_ =>
                new ConnectionProvider(configuration.GetValue<string>("Rabbit")));
            services.AddTransient<IMessageProducer, MessageProducer>();
            services.AddTransient<IHttpRequestService, HttpRequestService>();
            services.AddScoped<IFirebaseAuthService, FirebaseAuthService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddFirebaseApp();
            services.Configure<RecommendationServiceOptions>(configuration.GetSection("RecommendationService"));
            services.Configure<RabbitQueuesOptions>(configuration.GetSection("RabbitQueues"))
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IUserService, UserService>();
            services.Configure<RabbitQueuesOptions>(configuration.GetSection("RabbitQueues"));
            services.Configure<LessonBackgroundOptions>(configuration.GetSection("LessonBackgroundService"));
            services.AddHostedService<LessonBackgroundService>();
            services.AddScoped<QueriesSenderService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
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

        private static void AddFirebaseApp(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile($"{Environment.CurrentDirectory}/Resources/FirebaseServiceAccountKey.json")
            });
        }

        public static void AddFileService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("AzureBlobStorageSettings")
                .GetValue<string>("ConnectionString");

            services.AddScoped(_ =>
                new BlobServiceClient(connectionString));

            services.AddSingleton(configuration.GetSection("AzureBlobStorageSettings").Get<BlobContainerOptions>());
            services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            services.AddScoped<IEasySpeakFileService, EasySpeakFileService>();
        }
    }
}
