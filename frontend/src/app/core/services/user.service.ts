import { Injectable } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/user';

    constructor(private httpService: HttpService) { }

    public getUser() {
        return this.httpService.get<IUserInfo>(`${this.routePrefix}`);
    }

    public updateUser(updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}`, updatedUser);
    }
}
