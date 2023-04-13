namespace EasySpeak.Core.Common.DTO.User;

public class NewRecommendationDto
{
    public long Id { get; set; }
    public int Compatibility { get; set; }

    public ICollection<long> Users { get; set; } = new List<long>();

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {"id", Id},
            {"compatibility", Compatibility},
            {"users", Users}
        };
    }
}