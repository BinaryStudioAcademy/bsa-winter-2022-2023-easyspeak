import { Component, Input, OnInit } from '@angular/core';
import { FriendshipService } from '@core/services/friendship.service';
import { UserService } from '@core/services/user.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import { UserCard, UserFriendshipStatus } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';

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
        private friendService: FriendshipService,
        private userService: UserService,
    ) {}

    ngOnInit(): void {
        this.user.tags = [...new Set(this.user.tags)];
        this.userService.getUser().subscribe(u => {
            this.currentUser = u;
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
        this.friendService.createFriendship({ email: this.user.email! }).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Acceptor;
        });
    }

    onAcceptClicked() {
        this.friendService.acceptFriendship({ email: this.user.email! })
            .subscribe(() => {
                this.user.userFriendshipStatus = UserFriendshipStatus.Friend;
            });
    }

    onRejectClicked() {
        this.friendService.acceptFriendship({ email: this.user.email! }).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Regular;
        });
    }
}
