import { Component, OnDestroy, OnInit } from '@angular/core';
import { FriendHubService } from '@core/hubs/friend-hub.service';
import { UserService } from '@core/services/user.service';
import { UserCard, UserFriendshipStatus } from '@shared/models/user/user-card';

@Component({
    selector: 'app-friends-page',
    templateUrl: './friends-page.component.html',
    styleUrls: ['./friends-page.component.sass'],
})
export class FriendsPageComponent implements OnInit, OnDestroy {
    constructor(
        private friendHub: FriendHubService,
        private userService: UserService,
    ) {
    }

    requests: UserCard[] = [];

    friends: UserCard[] = [];

    async ngOnInit(): Promise<void> {
        await this.friendHub.start();
        this.userService.getFriends().subscribe(users => {
            this.friends = users.filter(u => u.userFriendshipStatus === UserFriendshipStatus.Friend);
            this.requests = users.filter(u => u.userFriendshipStatus !== UserFriendshipStatus.Friend);
        });
    }

    async ngOnDestroy(): Promise<void> {
        await this.friendHub.stop();
    }
}
