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
        public static string GetUserAvatar(this User user)
        {
            return string.IsNullOrEmpty(user.EmojiName) ? UserImage(user) : user.EmojiName;
        }

        private static string? GetUserImage(User user)
        {
            return user.ImageId != null ? user.Image.Url : "";
        }
    }
}
