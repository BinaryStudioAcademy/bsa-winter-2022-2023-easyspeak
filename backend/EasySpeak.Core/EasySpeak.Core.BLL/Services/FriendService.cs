using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Friend;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IMapper _mapper;
        private readonly EasySpeakCoreContext _context;
        private readonly IFirebaseAuthService _authService;
        private readonly INotificationService notificationService;

        public FriendService(IMapper mapper, EasySpeakCoreContext context, IFirebaseAuthService authService, INotificationService notificationService)
        {
            _mapper = mapper;
            _context = context;
            _authService = authService;
            this.notificationService = notificationService;
        }

        public async Task<FriendEmailDto> AcceptFriendshipAsync(FriendEmailDto friendDto)
        {
            await SetFriendshipStatus(friendDto.Email, FriendshipStatus.Confirmed);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == friendDto.Email);
            await notificationService.AddNotificationAsync(Common.Enums.NotificationType.friendshipAcception, user!.Id);
            return friendDto;
        }

        public async Task<FriendEmailDto> AddFriendAsync(FriendEmailDto friendEmailDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == friendEmailDto.Email);
            var friend = new Friend
            {
                UserId = user!.Id,
                RequesterId = _authService.UserId,
                FriendshipStatus = FriendshipStatus.Pending,
            };

            _context.Friends.Add(friend);

            await _context.SaveChangesAsync();

            await notificationService.AddNotificationAsync(Common.Enums.NotificationType.friendshipRequest, user!.Id);

            return _mapper.Map<FriendEmailDto>(friend);
        }

        public async Task<FriendEmailDto> RejectFriendshipAsync(FriendEmailDto friendDto)
        {
            await SetFriendshipStatus(friendDto.Email, FriendshipStatus.Rejected);
            return friendDto;
        }

        private async Task SetFriendshipStatus(string requesterEmail, FriendshipStatus friendshipStatus)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == requesterEmail);
            var friendship = await _context.Friends.FirstOrDefaultAsync(f => f.UserId == _authService.UserId && f.RequesterId == user!.Id);
            friendship!.FriendshipStatus = friendshipStatus;
            _context.Friends.Update(friendship);
            await _context.SaveChangesAsync();
        }
    }
}
