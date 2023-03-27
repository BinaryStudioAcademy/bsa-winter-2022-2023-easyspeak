import { Injectable } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';

import { Lesson } from 'src/app/models/lessons/lesson';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    public routePrefix = '/users';

    constructor(private httpService: HttpService) { }

    public getUser(userId: number) {
        return this.httpService.getById<IUserInfo>(`${this.routePrefix}`, userId);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public enrollUserToLesson(lesson: Lesson) {
        return this.httpService.put<Lesson>(`${this.routePrefix}/enroll/${lesson.id}`, lesson);
    }
}
