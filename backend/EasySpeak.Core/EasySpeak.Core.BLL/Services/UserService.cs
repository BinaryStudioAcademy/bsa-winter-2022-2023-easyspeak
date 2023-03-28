using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
namespace EasySpeak.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<List<UserShortInfoDto>> GetFilteredUsers(string? language = null, string[]? levels = null, string[]? interests = null, int? compatibility = null)
        {
            var users = _context.Users.Include(u => u.Tags);

            IQueryable<User> filteredUsers = users;

            if(language is not null)
            {
                filteredUsers = filteredUsers.Where(u => _mapper.Map<string>(u.Language) == language);
            }
            if(levels is not null && levels.Length != 0)
            {
                var eLevels = levels.Select(c => _mapper.Map<LanguageLevel>(c));
                filteredUsers = filteredUsers.Where(u => eLevels.Contains(u.LanguageLevel));
            }
            if(interests is not null && interests.Length != 0)
            {
                filteredUsers = filteredUsers.Where(u => u.Tags.Select(t=>t.Name).Intersect(interests).Count() > 0);
            }
            return await filteredUsers.ProjectTo<UserShortInfoDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
