import { Injectable } from '@angular/core';
import { INewUser } from '@shared/models/INewUser';
import { IUserInfo } from '@shared/models/IUserInfo';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/users';

    constructor(private httpService: HttpService) {}

    public getUser() {
        return this.httpService.get<IUserInfo>(`${this.routePrefix}`);
    }

    public updateCurrentUser(updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/current}`, updatedUser);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public createUser(user: INewUser) {
        return this.httpService.post<INewUser>(`${this.routePrefix}`, user);
    }
}
