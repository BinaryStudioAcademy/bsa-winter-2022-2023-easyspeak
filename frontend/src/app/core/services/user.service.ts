import { Injectable } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';

import { Lesson } from 'src/app/models/lessons/lesson';

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

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public enrollUserToLesson(lessonId: number) {
        return this.httpService.put<Lesson>(`${this.routePrefix}/enroll/${lessonId}`, {} as Lesson);
    }

    public getTagNames() {
        return this.httpService.get<string[]>(`${this.routePrefix}/tags`);
    }
}
