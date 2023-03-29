import { Component } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.component.html',
    styleUrls: ['./landing-page.component.sass'],
})
export class LandingPageComponent {
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

    scrollToElement($element: Element): void {
        $element.scrollIntoView({ behavior: 'smooth', block: 'start', inline: 'nearest' });
    }
}
