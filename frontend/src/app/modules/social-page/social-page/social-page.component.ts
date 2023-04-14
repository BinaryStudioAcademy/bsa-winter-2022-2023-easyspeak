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

    currentPage: number = 0;

    itemsOnPage: number;

    pagesCount: number;

    filtersSaved: UserFilter;

    public constructor(private userService: UserService) {}

    ngOnInit(): void {
        this.updateUsers(this.filtersSaved);

        this.userService.getAmountOfItemsOnPage().subscribe(itemsOnPage => {
            this.itemsOnPage = itemsOnPage;
        });
    }

    onFilterChanges(filters: UserFilter) {
        this.filtersSaved = filters;

        this.currentPage = 0;

        this.updateUsers(filters);
    }

    onChanged(numberVar: number) {
        this.currentPage = numberVar;

        this.updateUsers(this.filtersSaved);
    }

    updateUsers(filters: UserFilter | undefined) {
        this.users$ = this.userService.getUsersPagination(this.currentPage, filters).pipe(
            map(usersWithPages => usersWithPages.userShortInfoDtos),
        );

        this.userService.getUsersPagination(this.currentPage, filters).subscribe(users => {
            this.pagesCount = users.pagesCount;
        });
    }
}
