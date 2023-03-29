import { Injectable } from '@angular/core';
import { INewUser } from '@shared/models/INewUser';
import { ITopic } from '@shared/models/ITopic';
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

    public addTags(topics: ITopic[]) {
        return this.httpService.post<ITopic[]>(`${this.routePrefix}/tags`, topics);
    }

    public updateUser(userId: number, updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}/${userId}`, updatedUser);
    }

    public createUser(user: INewUser) {
        return this.httpService.post<INewUser>(`${this.routePrefix}`, user);
    }

    public enrollUserToLesson(lessonId: number) {
        return this.httpService.put<Lesson>(`${this.routePrefix}/enroll/${lessonId}`, {} as Lesson);
    }
}
