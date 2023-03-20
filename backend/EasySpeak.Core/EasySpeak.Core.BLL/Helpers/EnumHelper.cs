using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Helpers
{
    public static class EnumHelper
    {
        public static Sex MapSex(string sex)
        {
            var dict = new Dictionary<string, Sex>{
                        { "Female", Sex.Female },
                        { "Male", Sex.Male } };

            return dict[sex];
        }

        public static LanguageLevel MapLanguageLevel(string level)
        {
            var dict = new Dictionary<string, LanguageLevel>{
                        { "A1", LanguageLevel.A1 },
                        { "A2", LanguageLevel.A2 },
                        { "B1", LanguageLevel.B1 },
                        { "B2", LanguageLevel.B2 } ,
                        { "C1", LanguageLevel.C1 },
                        { "C2", LanguageLevel.C2 }};

            return dict[level];
        }
    }
}
