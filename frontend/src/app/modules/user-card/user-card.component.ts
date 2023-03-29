import { Component, Input } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent {
    @Input() user: UserCard = Utils.user;
}
