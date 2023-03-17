using EasySpeak.Core.Common.DTO;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators
{
    public class NewMessageDtoValidator : AbstractValidator<NewMessageDto>
    {
        public NewMessageDtoValidator()
        {
            RuleFor(m => m.Text).NotEmpty().MaximumLength(1000);
        }
    }
}
