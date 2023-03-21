import { Injectable } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/user';

    constructor(private httpService: HttpService) { }

    public getUserById(userId: number) {
        return this.httpService.getById<IUserInfo>(`${this.routePrefix}`, userId);
    }

    public updateUser(userId: number, userUpdates: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, userUpdates);
    }
}
