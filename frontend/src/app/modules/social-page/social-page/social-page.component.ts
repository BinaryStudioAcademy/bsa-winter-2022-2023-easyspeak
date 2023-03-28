import { Component, OnInit } from '@angular/core';
import { user } from '@angular/fire/auth';
import { UserService } from '@core/services/user.service';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';

import { UserFilter } from '../../../models/filters/userFilter';

@Component({
    selector: 'app-social-page',
    templateUrl: './social-page.component.html',
    styleUrls: ['./social-page.component.sass'],
})
export class SocialPageComponent implements OnInit {
    // users: UserCard[] = [
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 90,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 45,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 45,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 45,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 45,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    //     {
    //         name: 'Kaiya Torff',
    //
    //         country: 'Canada',
    //
    //         language: 'English',
    //
    //         imagePath: 'assets/user-card-icons/Photo.png',
    //
    //         languageLevel: 'B1',
    //
    //         tags: ['healthy', 'food', 'diet', 'sport', 'biology'],
    //
    //         status: 45,
    //
    //         flag: '../../../assets/user-card-icons/canada-flag.svg',
    //     },
    // ];

    public users: Observable<UserCard[]>;

    public constructor(private userService: UserService) {
    }

    ngOnInit(): void {
        this.users = this.userService.getUsers(null, null, null, null);
    }

    onFilterChanges(filters: UserFilter) {
        this.users = this.userService.getUsers(
            [...filters.languages][0],
            [...filters.langLevels],
            [...filters.topics],
            filters.compatibilities.size !== 0 ? +[...filters.compatibilities][0] : null,
        );
    }
}
