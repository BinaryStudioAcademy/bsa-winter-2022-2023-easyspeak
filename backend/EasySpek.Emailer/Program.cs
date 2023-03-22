using EasySpeak.Emailer.Interfaces;
using EasySpeak.Emailer.Services;
using FluentValidation.AspNetCore;
using EasySpeak.Core.Common.DTO;
using FluentValidation;
using EasySpek.Emailer.Validators;
using FluentValidation.Results;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMailService, SendGridMailService>();
builder.Services.AddScoped<IValidator<NewMailDto>, NewMailDtoValidator>();
builder.Services.AddCors();
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewMailDto>());

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

app.MapPost("/api/emailer/send", async (IValidator<NewMailDto> validator, NewMailDto mailDto) =>
{
    ValidationResult validationResult = await validator.ValidateAsync(mailDto);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }


    var mailService = new SendGridMailService(builder.Configuration);
    await mailService.SendEmailAsync(mailDto.To, mailDto.Subject, mailDto.Content);
    return Results.Created($"/{mailDto.To}", mailDto);
});

app.Run();