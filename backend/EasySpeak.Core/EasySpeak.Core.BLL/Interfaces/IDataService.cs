using EasySpeak.Core.Common.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IDataService
    {
        Task<List<TagWithImageDto>> GetTagsAsync();

        List<string> GetLanguages();
    }
}
