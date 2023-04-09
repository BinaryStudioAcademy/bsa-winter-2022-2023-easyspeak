import { Injectable } from '@angular/core';
import { INewUser } from '@shared/models/INewUser';
import { ITopic } from '@shared/models/ITopic';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ITag } from '@shared/models/user/ITag';
import { UserCard } from '@shared/models/user/user-card';
import { Observable } from 'rxjs';

import { Lesson } from 'src/app/models/lessons/lesson';

import { UserFilter } from '../../models/filters/userFilter';

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

    public updateUser(updatedUser: IUserInfo) {
        return this.httpService.put(`${this.routePrefix}`, updatedUser);
    }

    public addTags(topics: ITopic[]) {
        return this.httpService.post<ITopic[]>(`${this.routePrefix}/tags`, topics);
    }

    public createUser(user: INewUser) {
        return this.httpService.post<INewUser>(`${this.routePrefix}`, user);
    }

    public enrollUserToLesson(lessonId: number) {
        return this.httpService.put<Lesson>(`${this.routePrefix}/enroll/${lessonId}`, {} as Lesson);
    }

    public getUserTags() {
        return this.httpService.get<ITag[]>(`${this.routePrefix}/tags`);
    }

    public getUsers(userFilter?: UserFilter): Observable<UserCard[]> {
        return this.httpService.post<UserCard[]>(`${this.routePrefix}/recommended`, userFilter ?? ({} as UserFilter));
    }

    public isAdmin(): boolean {
        const user = localStorage.getItem('user');

        if (user) {
            return JSON.parse(user).isAdmin;
        }

        return false;
    }

    public getFriends(): Observable<UserCard[]> {
        return this.httpService.get<UserCard[]>(`${this.routePrefix}/friends`);
    }
}
