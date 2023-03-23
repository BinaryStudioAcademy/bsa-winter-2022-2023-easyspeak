using EasySpeak.Emailer.WebAPI.Interfaces;
using EasySpeak.Emailer.WebAPI.Services;
using EasySpeak.Core.Common.DTO;
using FluentValidation;
using EasySpek.Emailer.WebAPI.Validators;
using FluentValidation.Results;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMailService, SendGridMailService>();
builder.Services.AddScoped<IValidator<NewMailDto>, NewMailDtoValidator>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt => opt
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapPost("/api/emailer/send", (IMailService mailService, NewMailDto mailDto) =>
{
    return mailService.SendWithResulatResult(mailDto);
});

app.Run();