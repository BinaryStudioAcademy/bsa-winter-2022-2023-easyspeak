import { Component, Input, OnInit } from '@angular/core';
import { FriendshipService } from '@core/services/friendship.service';
import { UserCard, UserFriendshipStatus } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';
import languagesLib from 'iso-639-1';
import countriesLib from 'iso-3166-1';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { countryCodes } from './mappingLanguagetoCountry';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})

export class UserCardComponent implements OnInit {
    @Input() user: UserCard = Utils.user;

    userCountryFlag: string | undefined;

    userLanguageFlag: string | undefined;

    eUserFriendshipStatus = UserFriendshipStatus;

    constructor(
        private countriesService: CountriesTzLangProviderService,
        private friendService: FriendshipService,
    ) {}

    ngOnInit(): void {
        this.user.tags = [...new Set(this.user.tags)];
        this.userCountryFlag = this.countriesService.getCountriesList()
            .find((s: { name: string | undefined; }) => s.name === this.user.country)?.flag;
        this.setFlagByLanguage();
    }

    setFlagByLanguage() {
        if (!this.user.language) {
            return;
        }

        const languageCode = languagesLib.getCode(this.user.language);

        if (languageCode) {
            const country = countryCodes[languageCode];

            const fullCountry = countriesLib.whereAlpha2(country)?.country;

            this.userLanguageFlag = this.countriesService.getCountriesList()
                .find((s: { name: string | undefined; }) => s.name === fullCountry)?.flag;
        }
    }

    buttonGoToMessage() {
        return true;
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
        this.friendService.rejectFriendship({ email: this.user.email! }).subscribe(() => {
            this.user.userFriendshipStatus = UserFriendshipStatus.Regular;
        });
    }
}
