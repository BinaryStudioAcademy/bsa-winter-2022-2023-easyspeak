using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Entities;
using FluentValidation;

namespace EasySpeak.Core.WebAPI.Validators
{
    public class NewUserDtoValidator : AbstractValidator<NewUserDto>
    {
        public NewUserDtoValidator()
        {
            RuleFor(u => u.Country).NotEmpty().IsEnumName(typeof(Country));
            RuleFor(u => u.Language).NotEmpty().IsEnumName(typeof(Language));
            RuleFor(u => u.Timezone).NotEmpty().IsEnumName(typeof(Timezone));
            RuleFor(u => u.FirstName).NotEmpty().Matches(@"^[A-Za-z\s]*$").Length(3, 30);
            RuleFor(u => u.LastName).NotEmpty().Matches(@"^[A-Za-z\s]*$").Length(3, 30);
            RuleFor(u => u.Age).InclusiveBetween(6, 99);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Sex).NotEmpty().IsEnumName(typeof(Sex));
            RuleFor(u => u.LanguageLevel).NotEmpty().IsEnumName(typeof(LanguageLevel));
        }
    }
}