using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.MappingProfiles;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.WebAPI.Extentions;
using EasySpeak.Core.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", reloadOnChange: true, optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
builder.Services.AddEasySpeakCoreContext(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterCustomServices();

//mapper
builder.Services.AddAutoMapper(c =>
{
    c.AddProfile(new LessonsProfile());
    c.AddProfile(new UserProfile());
    c.AddProfile(new TagForLessonProfile());
    c.AddProfile(new QuestionsProfile());
    c.AddProfile(new SubQuestionsProfile());
});

builder.Services.AddSwaggerGen();
builder.Services.AddValidation();
builder.Services.AddFirebaseAuthorization(builder.Configuration);
builder.Services.AddTransient<ILessonsService, LessonsService>();


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

app.UseEndpoints(endpoinds =>
{
    endpoinds.MapHealthChecks("/health");
    endpoinds.MapControllers();
});

app.UseCodiCoreContext();

app.Run();
