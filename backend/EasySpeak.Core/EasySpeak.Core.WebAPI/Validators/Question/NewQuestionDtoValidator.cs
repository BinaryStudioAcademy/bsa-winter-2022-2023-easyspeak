using EasySpeak.Core.Common.DTO;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators
{
    public class NewQuestionDtoValidator : AbstractValidator<NewQuestionDto>
    {
        public NewQuestionDtoValidator()
        {
            RuleFor(sq => sq.Topic).NotEmpty().MaximumLength(100);
        }
    }
}
