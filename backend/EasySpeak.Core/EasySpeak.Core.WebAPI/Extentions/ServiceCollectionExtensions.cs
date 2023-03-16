using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.MappingProfiles;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.WebAPI.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            services.AddTransient<ISampleService, SampleService>();
            services.AddTransient<ILessonsService, LessonsService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                Assembly.GetAssembly(typeof(SampleProfile)),
                Assembly.GetAssembly(typeof(LessonsProfile)),
                Assembly.GetAssembly(typeof(UserProfile)),
                Assembly.GetAssembly(typeof(TagForLessonProfile)),
                Assembly.GetAssembly(typeof(QuestionsProfile)),
                Assembly.GetAssembly(typeof(SubQuestionsProfile)));
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
    }
}
