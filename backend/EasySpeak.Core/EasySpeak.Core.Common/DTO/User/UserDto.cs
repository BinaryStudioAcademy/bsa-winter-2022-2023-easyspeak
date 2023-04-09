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
    public bool IsAdmin { get; set; }
    public ICollection<TagDto>? Tags { get; set; }

    public UserDto()
    {
        Tags = new List<TagDto>();
    }

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {"fullName", FirstName + " " + LastName},
            {"country", Country},
            {"language", Language},
            {"languageLevel", LanguageLevel},
            {"ageGroup", GetAgeCategory()}
        };
    }

    private string GetAgeCategory()
    {
        var age = DateTime.Now.Year - BirthDate.Year;

        switch (age)
        {
            case > 55:
                return "Old";
            case >=45:
                return "Old Adults";
            case >= 35:
                return "Adults";
            case >= 25:
                return "Middle-aged Adults";
            case >= 18:
                return "Young Adults";
            default:
                return "Kids";
        }
    }
}