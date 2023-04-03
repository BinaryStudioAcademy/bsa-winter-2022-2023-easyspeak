import { Injectable } from '@angular/core';
import { INotification } from '@shared/models/INotification';
import { INewNotification } from '@shared/models/notification/INewNotification';

import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root',
})
export class NotificationService {
    constructor(private httpService: HttpService) { }

    private routePrefix = '/notifications';

    public createNotification(notification: INewNotification) {
        return this.httpService.post<INotification>(this.routePrefix, notification);
    }

    public readNotification(notificationId: number) {
        return this.httpService.updateByUd<INotification>(this.routePrefix, notificationId);
    }

    public readAllNotifications() {
        return this.httpService.put(`${this.routePrefix}/readAll`, null);
    }

    public getNotifications() {
        return this.httpService.get<INotification[]>(this.routePrefix);
    }
}
