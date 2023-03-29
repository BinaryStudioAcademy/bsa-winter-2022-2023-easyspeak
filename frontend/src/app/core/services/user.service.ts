import { Injectable } from '@angular/core';
import { INewUser } from '@shared/models/INewUser';
import { ITopic } from '@shared/models/ITopic';
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

    public addTags(topics: ITopic[]) {
        return this.httpService.post<ITopic[]>(`${this.routePrefix}`, topics);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public createUser(user: INewUser) {
        return this.httpService.post<INewUser>(`${this.routePrefix}`, user);
    }
}
