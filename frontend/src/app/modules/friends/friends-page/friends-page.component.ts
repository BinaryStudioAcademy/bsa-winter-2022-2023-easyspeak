import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserService } from '@core/services/user.service';
import { UserCard, UserFriendshipStatus } from '@shared/models/user/user-card';

@Component({
    selector: 'app-friends-page',
    templateUrl: './friends-page.component.html',
    styleUrls: ['./friends-page.component.sass'],
})
export class FriendsPageComponent implements OnInit {
    constructor(
        private userService: UserService,
    ) {
    }

    requests: UserCard[] = [];

    friends: UserCard[] = [];

    ngOnInit(): void {
        this.userService.getFriends().subscribe(users => {
            this.friends = users.filter(u => u.userFriendshipStatus === UserFriendshipStatus.Friend);
            this.requests = users.filter(u => u.userFriendshipStatus !== UserFriendshipStatus.Friend);
        });
    }

}
