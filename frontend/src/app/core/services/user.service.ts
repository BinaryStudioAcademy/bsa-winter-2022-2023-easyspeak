import { Injectable } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';

import { UserFilter } from '../../models/filters/userFilter';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/users';

    constructor(
        private httpService: HttpService,
    ) { }

    public getUser() {
        return this.httpService.get<IUserInfo>(`${this.routePrefix}`);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public getUsers(userFilter: UserFilter | null): Observable<UserCard[]> {
        return this.httpService.post<UserCard[]>(`${this.routePrefix}/short`, userFilter);
    }
}
