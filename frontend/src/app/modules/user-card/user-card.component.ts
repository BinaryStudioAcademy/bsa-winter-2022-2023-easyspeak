import { Component, Input, OnInit } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';
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

    @Input() isFriend: boolean = false;

    userCountryFlag: string | undefined;

    userLanguageFlag: string | undefined;

    constructor(private countriesService: CountriesTzLangProviderService) {}

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

    buttonFollow() {
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
}
