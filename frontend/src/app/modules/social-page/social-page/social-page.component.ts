import { Component, OnDestroy, OnInit } from '@angular/core';
import { FriendHubService } from '@core/hubs/friend-hub.service';
import { UserService } from '@core/services/user.service';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';

import { UserFilter } from '../../../models/filters/userFilter';

@Component({
    selector: 'app-social-page',
    templateUrl: './social-page.component.html',
    styleUrls: ['./social-page.component.sass'],
})
export class SocialPageComponent implements OnInit, OnDestroy {
    public users$: Observable<UserCard[]>;

    public constructor(
        private userService: UserService,
        private friendHub: FriendHubService,
    ) {
    }

    async ngOnInit(): Promise<void> {
        this.users$ = this.userService.getUsers();
        await this.friendHub.start();
    }

    async ngOnDestroy(): Promise<void> {
        await this.friendHub.stop();
    }

    onFilterChanges(filters: UserFilter) {
        this.users$ = this.userService.getUsers(filters);
    }
}
