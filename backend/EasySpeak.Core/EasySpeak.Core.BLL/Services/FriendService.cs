using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Friend;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly EasySpeakCoreContext _context;
        private readonly IFirebaseAuthService _authService;
        private readonly INotificationService _notificationService;

        public FriendService(EasySpeakCoreContext context, IFirebaseAuthService authService, INotificationService notificationService)
        {
            _context = context;
            _authService = authService;
            _notificationService = notificationService;
        }

        public async Task AcceptFriendshipAsync(FriendEmailDto friendDto)
        {
            await SetFriendshipStatus(friendDto.Email, FriendshipStatus.Confirmed);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == friendDto.Email);
            await _notificationService.AddNotificationAsync(Common.Enums.NotificationType.friendshipAcception, user!.Id);
        }

        public async Task<bool> AddFriendAsync(FriendEmailDto friendDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == friendDto.Email);
            if (user is null || await _context.Friends
                .AnyAsync(f => 
                (f.RequesterId == user.Id && f.UserId == _authService.UserId 
                    || f.UserId == user.Id && f.RequesterId == _authService.UserId)
                && f.FriendshipStatus != FriendshipStatus.Rejected))
            {
                return false;
            }
            var friendship = await _context.Friends.FirstOrDefaultAsync(f => f.UserId == user.Id && f.RequesterId == _authService.UserId);
            if (friendship is null)
            {
                var friend = new Friend
                {
                    UserId = user!.Id,
                    RequesterId = _authService.UserId,
                    FriendshipStatus = FriendshipStatus.Pending,
                };

                _context.Friends.Add(friend);

                await _context.SaveChangesAsync();

                await _notificationService.AddNotificationAsync(Common.Enums.NotificationType.friendshipRequest, user!.Id);
            }
            else
            {
                friendship.FriendshipStatus = FriendshipStatus.Pending;
                _context.Friends.Update(friendship);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task RejectFriendshipAsync(FriendEmailDto friendDto)
        {
            await SetFriendshipStatus(friendDto.Email, FriendshipStatus.Rejected);
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
