using EasySpeak.Core.Common.DTO;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators
{
    public class NewLessonDtoValidator : AbstractValidator<NewLessonDto>
    {
        public NewLessonDtoValidator()
        {
            RuleFor(l => l.Name).NotEmpty().MaximumLength(100);
            RuleFor(l => l.Description).NotEmpty().MaximumLength(1000);
            RuleFor(l => l.StartAt).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(l => l.LimitOfUsers).GreaterThan(0).When(i => i.LimitOfUsers != null);
        }
    }
}