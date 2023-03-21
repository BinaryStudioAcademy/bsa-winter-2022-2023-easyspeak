using EasySpeak.Emailer.Interfaces;
using EasySpeak.Emailer.Services;
using FluentValidation.AspNetCore;
using EasySpeak.Core.Common.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMailService, SendGridMailService>();
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewMailDto>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/emailer/send", (NewMailDto mailDto) =>
{
    return mailDto;
});

app.Run();