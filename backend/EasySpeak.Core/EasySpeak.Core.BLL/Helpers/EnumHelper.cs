using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Helpers
{
    public static class EnumHelper
    {
        public static Sex MapSex(string sex)
        {
            var dict = new Dictionary<string, Sex>{
                        { "Female", Sex.Female },
                        { "Male", Sex.Male },
                        { "Non Binary", Sex.NonBinary },
                        { "Do not want to specify", Sex.DoNotWantToSpecify } };

            return dict[sex];
        }

        public static string MapSexToString(Sex sex)
        {
            var dict = new Dictionary<Sex, string>{
                        { Sex.Female, "Female" },
                        { Sex.Male, "Male" },
                        { Sex.NonBinary, "Non Binary" },
                        { Sex.DoNotWantToSpecify, "Do not want to specify" } };

            return dict[sex];
        }

        public static LanguageLevel MapLanguageLevel(string level)
        {
            var dict = new Dictionary<string, LanguageLevel>{
                        { "B1", LanguageLevel.B1 },
                        { "B2", LanguageLevel.B2 } ,
                        { "C1", LanguageLevel.C1 },
                        { "C2", LanguageLevel.C2 }};

            return dict[level];
        }

        public static FriendshipStatus MapFriendshipStatus(string status)
        {
            var dict = new Dictionary<string, FriendshipStatus>{
                         { "Pending", FriendshipStatus.Pending },
                         { "Confirmed", FriendshipStatus.Confirmed },
                         { "Rejected", FriendshipStatus.Rejected },};

            return dict[status];
        }
    }
}
