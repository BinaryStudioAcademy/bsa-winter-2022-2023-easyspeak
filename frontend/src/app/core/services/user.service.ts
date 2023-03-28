import { Injectable } from '@angular/core';
import { Router, UrlSerializer } from '@angular/router';
import { IUserInfo } from '@shared/models/IUserInfo';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/users';

    constructor(
        private httpService: HttpService,
        private router: Router,
        private serializer: UrlSerializer,
    ) { }

    public getUser() {
        return this.httpService.get<IUserInfo>(`${this.routePrefix}`);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public getUsers(
        language: string | null,
        levels: string[] | null,
        interests: string[] | null,
        compatibility: number | null,
    ): Observable<UserCard[]> {
        const tree = this.router.createUrlTree(
            ['short'],
            { queryParams: {
                language, levels, interests, compatibility,
            } },
        );
        const query = this.serializer.serialize(tree);

        return this.httpService.get<UserCard[]>(`${this.routePrefix}${query}`);
    }
}
