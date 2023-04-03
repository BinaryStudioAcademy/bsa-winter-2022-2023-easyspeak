import { Component, Input, OnInit } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent implements OnInit {
    @Input() user: UserCard = Utils.user;

    constructor(private countriesService: CountriesTzLangProviderService) {}

    ngOnInit(): void {
        this.user.tags = [...new Set(this.user.tags)];
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
