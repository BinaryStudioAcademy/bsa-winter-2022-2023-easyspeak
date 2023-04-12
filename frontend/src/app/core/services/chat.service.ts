import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { IUserShort } from '@shared/models/IUserShort';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ChatService {
    private currentUser: IUserShort;

    private routePrefix = '/chat';

    constructor(private httpService: HttpService) {
        this.currentUser = JSON.parse(localStorage.getItem('user') as string);
    }

    checkForChat(userId: number): Observable<unknown> {
        return this.httpService.get(`${this.routePrefix}/checkForChat/${userId}/${this.currentUser.id}`);
    }

    createChat(userId: number): Observable<unknown> {
        return this.httpService.post(`${this.routePrefix}/createChat`, [userId, this.currentUser.id]);
    }
}
