namespace EasySpeak.Core.DAL.Entities
{
    public class EasySpeakFile : Entity<long>
    {
        public string? Url { get; set; }

        public long UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
