using EasySpeak.Core.Common.DTO;
using FluentValidation;

namespace EasySpek.Emailer.Validators
{
    public class NewMailDtoValidator : AbstractValidator<NewMailDto>
    {
        public NewMailDtoValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage("Subject is required.")
                .MaximumLength(100)
                .WithMessage("Max size of subject is 100");
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Subject is required.")
                .MaximumLength(1000)
                .WithMessage("Max size of subject is 1000");
        }
    }
}
