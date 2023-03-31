import { Component, Input, OnInit } from '@angular/core';
import { UserCard } from '@shared/models/user/user-card';
import { Utils } from '@shared/utils/user-card.utils';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrls: ['./user-card.component.sass'],
})
export class UserCardComponent implements OnInit {
    @Input() user: UserCard = Utils.user;

    ngOnInit(): void {
        this.user.tags = [...new Set(this.user.tags)];
    }
}
