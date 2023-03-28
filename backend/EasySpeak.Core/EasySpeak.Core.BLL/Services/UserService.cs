using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class UserService : BaseService, IUserService
{
    private readonly IFirebaseAuthService _authService;

    public UserService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService authService) 
        : base(context, mapper)
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

    public async Task<UserDto> UpdateCurrentUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.Id = _authService.UserId;

        if (userDto.Tags != null)
        {
            var tagsNames = userDto.Tags.Select(x => x.Name).ToList();
            user.Tags = _context.Tags.Where(t => tagsNames.Contains(t.Name)).ToList();
        }

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }
}