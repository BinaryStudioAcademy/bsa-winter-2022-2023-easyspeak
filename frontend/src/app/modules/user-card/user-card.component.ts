import { Component, Input } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent {
    @Input() user: UserCard;
}
