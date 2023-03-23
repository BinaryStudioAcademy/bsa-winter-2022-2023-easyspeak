using EasySpeak.Core.Common.DTO;
namespace EasySpeak.Emailer.WebAPI.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
        Task<IResult> SendWithResulatResult(NewMailDto mailDto);
    }
}
