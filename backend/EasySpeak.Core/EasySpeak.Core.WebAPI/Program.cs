using EasySpeak.Core.WebAPI.Extensions;
using EasySpeak.Core.WebAPI.Extentions;
using EasySpeak.Core.WebAPI.Hubs;
using EasySpeak.Core.WebAPI.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", reloadOnChange: true, optional: true)
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(),true)
    .Build();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllers();
builder.Services.AddEasySpeakCoreContext(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterCustomServices(builder.Configuration);

builder.Services.AddAutoMapper();
builder.Services.AddSwaggerGen();
builder.Services.AddValidation();
builder.Services.AddFirebaseAuthorization(builder.Configuration);
builder.Services.AddSignalR();  
builder.Services.AddFileService(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddHealthChecks();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.WebHost.UseUrls("http://*:5050");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GenericExceptionHandlerMiddleware>();

app.UseCors(opt => opt
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<FirebaseAuthMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapHub<SignalRtcHub>("/signaling");
    endpoints.MapControllers();
});


app.UseCodiCoreContext();

app.Run();
