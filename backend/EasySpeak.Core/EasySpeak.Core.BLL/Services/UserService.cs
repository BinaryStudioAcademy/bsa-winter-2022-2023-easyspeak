using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Filter;
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
        private readonly IFirebaseAuthService _authService;
        public UserService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService authService) : base(context, mapper)
        {
            _authService = authService;
        }

        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<UserDto> GetUserAsync()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter)
        {
            var users = _context.Users.Include(u => u.Tags);

            IQueryable<User> filteredUsers = users;

            if(userFilter.Language is not null)
            {
                filteredUsers = filteredUsers.Where(u => _mapper.Map<string>(u.Language) == userFilter.Language);
            }
            if(userFilter.LangLevels is not null && userFilter.LangLevels.Length != 0)
            {
                var eLevels = userFilter.LangLevels.Select(c => _mapper.Map<LanguageLevel>(c));
                filteredUsers = filteredUsers.Where(u => eLevels.Contains(u.LanguageLevel));
            }
            if(userFilter.Topics is not null && userFilter.Topics.Length != 0)
            {
                filteredUsers = filteredUsers.Where(u => u.Tags.Select(t=>t.Name).Intersect(userFilter.Topics).Count() > 0);
            }
            return await filteredUsers.ProjectTo<UserShortInfoDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
