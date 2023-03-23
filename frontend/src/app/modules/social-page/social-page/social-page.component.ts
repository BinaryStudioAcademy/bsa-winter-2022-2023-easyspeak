import { Component } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';

@Component({
    selector: 'app-social-page',
    templateUrl: './social-page.component.html',
    styleUrls: ['./social-page.component.sass'],
})
export class SocialPageComponent {
    users: UserCard[] = [
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 90,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 45,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 45,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 45,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 45,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
        {
            name: 'Kaiya Torff',

            country: 'Canada',

            language: 'English',

            imagePath: 'assets/user-card-icons/Photo.png',

            languageLevel: 'B1',

            tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

            status: 45,

            flag: '../../../assets/user-card-icons/canada-flag.svg',
        },
    ];
}
