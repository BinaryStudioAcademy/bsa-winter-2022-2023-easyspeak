import { Component, OnInit } from '@angular/core';
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
    public users$: Observable<UserCard[]>;

    public constructor(
        private userService: UserService,
    ) {
    }

    ngOnInit(): void {
        this.users$ = this.userService.getUsers();
    }

    onFilterChanges(filters: UserFilter) {
        this.users$ = this.userService.getUsers(filters);
    }
}
