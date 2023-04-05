using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Services
{
    public class DataService : IDataService
    {
        private readonly EasySpeakCoreContext context;
        private readonly IMapper mapper;

        public DataService(EasySpeakCoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<string> GetLanguages()
        {
            return GetEnumStringValues<Language>();
        }

        public Task<List<TagWithImageDto>> GetTagsAsync()
        {
            return context.Tags.ProjectTo<TagWithImageDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        private List<string> GetEnumStringValues<T>() where T : struct, Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select((e) => mapper.Map<string>(e)).ToList();
        }
    }
}
