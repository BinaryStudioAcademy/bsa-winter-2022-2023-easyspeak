namespace EasySpeak.Core.DAL.Entities
{
    public class UploadFile : Entity<long>
    {
        public string? Url { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
