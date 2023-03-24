import { Component } from '@angular/core';
import { SpinnerService } from '@core/services/spinner.service';
import { UserCard } from '@shared/models/user/user-card';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.component.html',
    styleUrls: ['./landing-page.component.sass'],
})
export class LandingPageComponent {
    // eslint-disable-next-line no-empty-function
    userT: UserCard = {
        name: 'Alfredo Culhane',

        country: 'Canada',

        language: 'English',

        imagePath: '../../../assets/user-card-icons/Man Curly Hair.svg',

        languageLevel: 'B1',

        tags: ['healthy', 'food', 'diet', 'sport', 'biology'],

        status: 70,

        flag: '../../../assets/user-card-icons/canada-flag.svg',
    };

    constructor(private spinnerService: SpinnerService) {}
}
