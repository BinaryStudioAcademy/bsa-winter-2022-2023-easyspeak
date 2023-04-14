import { Component, OnInit } from '@angular/core';
import { UserService } from '@core/services/user.service';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { UserFilter } from '../../../models/filters/userFilter';

@Component({
    selector: 'app-social-page',
    templateUrl: './social-page.component.html',
    styleUrls: ['./social-page.component.sass'],
})
export class SocialPageComponent implements OnInit {
    public users$: Observable<UserCard[]>;

    public slicedUsers$: Observable<UserCard[][]>;

    currentPage: number = 0;

    paginationPages: number = 10;

    public userCount$: Observable<number>;

    public constructor(
        private userService: UserService,
    ) {
    }

    ngOnInit(): void {
        this.users$ = this.userService.getUsers();

        this.userCount$ = this.users$.pipe(
            map(users => users.length),
        );
        this.slicedUsers$ = this.users$.pipe(
            map((users) => this.chunkArray(users, this.paginationPages)),
        );
    }

    onFilterChanges(filters: UserFilter) {
        this.users$ = this.userService.getUsers(filters);

        this.userCount$ = this.users$.pipe(
            map(users => users.length),
        );

        this.slicedUsers$ = this.users$.pipe(
            map((users) => this.chunkArray(users, this.paginationPages)),
        );
    }

    onChanged(numberVar: number) {
        this.currentPage = numberVar - 1;
    }

    private chunkArray(myArray: UserCard[], chunkSize: number): UserCard[][] {
        const results = [];

        while (myArray.length) {
            results.push(myArray.splice(0, chunkSize));
        }

        return results;
    }

    getPageAmount = (first: number, second: number) => {
        if (first % second !== 0) {
            return Math.floor(first / second) + 1;
        }

        return Math.floor(first / second);
    };
}
