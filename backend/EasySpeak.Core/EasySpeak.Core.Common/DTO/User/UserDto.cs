using EasySpeak.Core.Common.DTO.Tag;

namespace EasySpeak.Core.Common.DTO.User;

public class UserDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime BirthDate { get; set; }
    public string Country { get; set; } = String.Empty;
    public string Sex { get; set; } = String.Empty;
    public string Language { get; set; } = String.Empty;
    public string LanguageLevel { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
    public ICollection<TagDto>? Tags { get; set; }

    public UserDto()
    {
        Tags = new List<TagDto>();
    }
}