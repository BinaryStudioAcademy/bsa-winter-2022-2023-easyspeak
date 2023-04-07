import { Component, Input, OnInit } from '@angular/core';
import { FriendHubService } from '@core/hubs/friend-hub.service';
import { FriendshipService } from '@core/services/friendship.service';
import { NotificationService } from '@core/services/notification.service';
import { UserService } from '@core/services/user.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import { INewNotification } from '@shared/models/notification/INewNotification';
import { UserCard, UserFriendshipStatus } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';
import { NotificationType } from '@shared/utils/user-notifications.util';
import { switchMap } from 'rxjs';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent implements OnInit {
    @Input() user: UserCard = Utils.user;

    currentUser: IUserInfo;

    eUserFriendshipStatus = UserFriendshipStatus;

    constructor(
        private countriesService: CountriesTzLangProviderService,
        private notificationService: NotificationService,
        private friendService: FriendshipService,
        private userService: UserService,

        private friendHub: FriendHubService,
    ) {}

    ngOnInit(): void {
        this.user.tags = [...new Set(this.user.tags)];
        this.userService.getUser().subscribe(u => {
            this.currentUser = u;
        });

        this.friendHub.listenFollow((email) => {
            if (this.user.email === email) {
                this.user.userFriendshipStatus = UserFriendshipStatus.Requester;
            }
        });
        this.friendHub.listenAccept((email) => {
            if (this.user.email === email) {
                this.user.userFriendshipStatus = UserFriendshipStatus.Friend;
            }
        });
        this.friendHub.listenReject((email) => {
            if (this.user.email === email) {
                this.user.userFriendshipStatus = UserFriendshipStatus.Regular;
            }
        });
    }

    public getUserCountryFlag() {
        return this.countriesService.getCountriesList().find((c) => c.name === this.user.country)?.flag;
    }

    getUserFirstName(): string {
        return this.user.name.split(' ')[0];
    }

    getUserLastName(): string {
        return this.user.name.split(' ')[1];
    }

    onFollowClick() {
        this.notificationService.createNotification({
            email: this.user.email,
            type: NotificationType.friendshipRequest,
            text: '',
        } as INewNotification).pipe(
            switchMap(() => this.friendService.createFriendship({ email: this.user.email! })),
        ).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Acceptor;
        });
    }

    onAcceptClicked() {
        this.notificationService.createNotification({
            email: this.user.email,
            type: NotificationType.friendshipAcception,
            text: '',
        } as INewNotification).pipe(
            switchMap(() => this.friendService.acceptFriendship({ email: this.user.email! })),
        ).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Friend;
        });
    }

    onRejectClicked() {
        this.friendService.acceptFriendship({ email: this.user.email! }).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Regular;
        });
    }
}
