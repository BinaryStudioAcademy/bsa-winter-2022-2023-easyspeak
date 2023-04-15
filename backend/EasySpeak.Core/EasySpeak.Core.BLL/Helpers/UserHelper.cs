using EasySpeak.Core.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Helpers
{
    public static class UserHelper
    {
        public static string? GetUserAvatar(this User user, EasySpeakFile? easySpeakFile = null)
        {
            return string.IsNullOrEmpty(user.EmojiName) ? GetUserImage(user, easySpeakFile) : user.EmojiName;
        }

        private static string? GetUserImage(User user, EasySpeakFile? easySpeakFile = null)
        {
            return easySpeakFile != null ? user.Image.Url : "";
        }
    }
}
