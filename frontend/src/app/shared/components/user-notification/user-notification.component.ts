import { Component, OnDestroy, OnInit } from '@angular/core';
import { NotificationsHubService } from '@core/hubs/notifications-hub.service';
import { HttpService } from '@core/services/http.service';
import { INotification } from '@shared/models/INotification';
import * as moment from 'moment';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-user-notification',
    templateUrl: './user-notification.component.html',
    styleUrls: ['./user-notification.component.sass'],
})
export class UserNotificationComponent implements OnInit, OnDestroy {
    readonly notificationsHub: NotificationsHubService;

    readonly httpService: HttpService;

    notifications: INotification[] = [];

    timespan: string;

    created: Date;

    notifySubscription: Subscription;

    constructor(notificationsHub: NotificationsHubService, httpService: HttpService) {
        this.notificationsHub = notificationsHub;
        this.httpService = httpService;

        this.created = new Date();
        this.timespan = moment(this.created).fromNow();
    }

    async ngOnInit() {
        // this.notifySubscription = await this.httpService.get<INotification[]>('/notification').subscribe((data) => {
        //     this.notifications = data;
        // });

        // await this.notificationsHub.start();

        // this.notificationsHub.listenMessages((msg) => {
        //     const broadcastMessage = JSON.parse(msg);

        //     const messages = {
        //         id: broadcastMessage.Id,
        //         text: broadcastMessage.Text,
        //         type: broadcastMessage.Type,
        //         isRead: broadcastMessage.IsRead,
        //     };

        //     this.notifications.push(messages);
        // });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone You have added someone. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone You have added someone. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });

        this.notifications.push({
            id: 2,
            text: 'You recieved new message. You have added someone You have added someone. You have added someone',
            email: undefined,
            type: 'Action',
            isRead: false,
            link: '/lessons/2',
        });
    }

    readNotification(notification: INotification) {
        notification.isRead = true;
        this.notifications = this.notifications.filter((n) => !n.isRead);

        this.httpService.put('/notification', notification.id).subscribe();
    }

    ngOnDestroy() {
        this.notificationsHub.stop();
        this.notifySubscription.unsubscribe();
    }
}
