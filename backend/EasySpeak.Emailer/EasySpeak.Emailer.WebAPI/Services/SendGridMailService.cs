using EasySpeak.Emailer.WebAPI.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using EasySpeak.Core.Common.DTO;
using FluentValidation;
using FluentValidation.Results;

namespace EasySpeak.Emailer.WebAPI.Services
{
    public class SendGridMailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly IValidator<NewMailDto> _validator;
        public SendGridMailService(IConfiguration configuration, IValidator<NewMailDto> validator)
        {
            _configuration = configuration;
            _validator = validator;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["Email"], "EasySpeak");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg);
        }

        public async Task<IResult> SendWithResulatResult(NewMailDto mailDto)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(mailDto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            await SendEmailAsync(mailDto.To, mailDto.Subject, mailDto.Content);
            return Results.Created($"/{mailDto.To}", mailDto);
        }
    }
}
