using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.Enums;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators.User
{
    public class NewUserDtoValidator : AbstractValidator<NewUserDto>
    {
        public NewUserDtoValidator()
        {
            RuleFor(u => u.Country).NotEmpty();
            RuleFor(u => u.Language).NotEmpty();
            RuleFor(u => u.Timezone).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty().Matches(@"^[A-Za-z\s]*$").Length(3, 30);
            RuleFor(u => u.LastName).NotEmpty().Matches(@"^[A-Za-z\s]*$").Length(3, 30);
            RuleFor(u => u.BirthDate).NotEmpty();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Sex).NotEmpty().IsEnumName(typeof(Sex));
            RuleFor(u => u.LanguageLevel).NotEmpty().IsEnumName(typeof(LanguageLevel));
        }
    }
}