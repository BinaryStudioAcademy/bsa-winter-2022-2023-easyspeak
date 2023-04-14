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

    itemsOnPage: number;

    public userCount$: Observable<number>;

    public constructor(
        private userService: UserService,
    ) {
    }

    ngOnInit(): void {
        this.users$ = this.userService.getUsers();

        this.userService.getAmountOfItemsOnPage().subscribe(count => {
            this.itemsOnPage = count;
        });

        this.setSlicedUsers();

        this.setUsersCount();
    }

    onFilterChanges(filters: UserFilter) {
        this.users$ = this.userService.getUsers(filters);

        this.setSlicedUsers();

        this.setUsersCount();
    }

    setSlicedUsers = () => {
        this.slicedUsers$ = this.users$.pipe(
            map((users) => this.chunkArray(users, this.itemsOnPage)),
        );
    };

    setUsersCount = () => {
        this.userCount$ = this.users$.pipe(
            map(users => users.length),
        );
    };

    onChanged(numberVar: number) {
        this.currentPage = numberVar;
    }

    private chunkArray(myArray: UserCard[], chunkSize: number): UserCard[][] {
        const results = [];

        // while (myArray.length) {
        //     results.push(myArray.splice(0, chunkSize));
        // }
        for (let i = 0; i < myArray.length; i += chunkSize) {
            results.push(myArray.slice(i, i + chunkSize));
        }

        return results;
    }

    getPageAmount = (usersCount: number) => {
        if (usersCount % this.itemsOnPage !== 0) {
            return Math.floor(usersCount / this.itemsOnPage) + 1;
        }

        return Math.floor(usersCount / this.itemsOnPage);
    };
}
