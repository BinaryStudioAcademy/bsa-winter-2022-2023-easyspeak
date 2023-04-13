import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { IUserShort } from '@shared/models/IUserShort';
import { Observable } from 'rxjs';
import {IChatPerson} from "@shared/models/chat/IChatPerson";
import {IMessageGroup} from "@shared/models/chat/IMessageGroup";
import {IMessage} from "@shared/models/chat/IMessage";

@Injectable({
    providedIn: 'root',
})
export class ChatService {
    private currentUser: IUserShort;

    private routePrefix = '/chat';

    constructor(private httpService: HttpService) {
        this.currentUser = JSON.parse(localStorage.getItem('user') as string);
    }

    checkForChat(userId: number): Observable<number> {
        return this.httpService.get(`${this.routePrefix}/checkForChat/${userId}/${this.currentUser.id}`);
    }

    createChat(userId: number): Observable<number> {
        return this.httpService.post(`${this.routePrefix}/createChat`, [userId, this.currentUser.id]);
    }

    getUnreadMessages(userId: number): Observable<number> {
        return this.httpService.get(`${this.routePrefix}/getUnreadMessages/${userId}`);
    }

    getChats(): Observable<IChatPerson[]> {
        return this.httpService.get<IChatPerson[]>(`${this.routePrefix}/lastSendMessages`);
    }

    getOneChat(chatId: number): Observable<IMessageGroup[]> {
        return this.httpService.get<IMessageGroup[]>(`${this.routePrefix}/chatMessages/${chatId}`);
    }

    sendMessage(message: IMessage): Observable<IMessage> {
        return this.httpService.post<IMessage>(`${this.routePrefix}/sendMessage`, message);
    }

    readMessages(chatId: number, userId: number): Observable<number[]> {
        return this.httpService.put<number[]>(`${this.routePrefix}/readMessage`, [chatId, userId]);
    }
}
