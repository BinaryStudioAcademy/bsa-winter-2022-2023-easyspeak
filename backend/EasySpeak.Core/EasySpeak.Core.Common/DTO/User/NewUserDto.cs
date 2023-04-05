namespace EasySpeak.Core.Common.DTO
{
    public class NewUserDto
    {
        public string Country { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Timezone { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string LanguageLevel { get; set; } = string.Empty;
    }
}
