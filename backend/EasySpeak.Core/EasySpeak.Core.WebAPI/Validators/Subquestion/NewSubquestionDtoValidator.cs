using EasySpeak.Core.Common.DTO;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators
{
    public class NewSubquestionDtoValidator : AbstractValidator<NewSubquestionDto>
    {
        public NewSubquestionDtoValidator()
        {
            RuleFor(sq => sq.Text).NotEmpty().MaximumLength(1000);
        }
    }
}
    
