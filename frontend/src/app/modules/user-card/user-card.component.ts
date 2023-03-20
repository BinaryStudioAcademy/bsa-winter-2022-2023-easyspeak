import { Component } from '@angular/core';

import { UserCard } from '../../models/user/user-card';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent {
    user: UserCard = {
        name: 'Kaiya Torff',

        country: 'Canada',

        language: 'English',

        imagePath: '../../../assets/user-card-icons/Photo.png',

        languageLevel: 'B1',

        tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

        status: 70,

        flag: '../../../assets/user-card-icons/canada-test-flag.svg',

    };
}
