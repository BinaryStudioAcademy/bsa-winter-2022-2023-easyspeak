
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class UserDto
{
    public Country Country { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}