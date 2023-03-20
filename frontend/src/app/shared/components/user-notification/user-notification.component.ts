import { Component, OnDestroy, OnInit } from '@angular/core';
import { NotificationsHubService } from '@core/hubs/notifications-hub.service';
import { HttpService } from '@core/services/http.service';
import { IUserNotification } from '@shared/models/IUserNotification';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-user-notification',
    templateUrl: './user-notification.component.html',
    styleUrls: ['./user-notification.component.sass'],
})
export class UserNotificationComponent implements OnInit, OnDestroy {
    readonly notificationsHub: NotificationsHubService;

    readonly httpService: HttpService;

    notifications: IUserNotification[] = [];

    notifySubscription: Subscription;

    count: number;

    constructor(notificationsHub: NotificationsHubService, httpService: HttpService) {
        this.notificationsHub = notificationsHub;
        this.httpService = httpService;

        this.notifications = [
            { id: 0, userId: 1, name: 'Tony Hawk', imgLink: 'tonyhawk.img', isRead: false },
            { id: 1, userId: 1, name: 'Bruce Lee', imgLink: 'brucelee.img', isRead: false },
            { id: 2, userId: 1, name: 'Steve Jobs', imgLink: 'stevejobs.img', isRead: false },
        ];
    }

    async ngOnInit() {
        this.notifySubscription = await this.httpService.get<IUserNotification>('/notifications').subscribe((data) => {
            this.notifications = data;
        });

        await this.notificationsHub.start();

        this.notificationsHub.listenMessages((msg) => {
            if (msg.id === 1) {
                this.notifications.push(msg);
            }

            console.info(`Notification for user was received: ${msg}`);
        });

        this.count = this.notifications.map((n) => n.isRead).length;
    }

    readNotification(notification: IUserNotification) {
        notification.isRead = true;
        this.notifications = this.notifications.filter((n) => !n.isRead);
        this.count = this.notifications.length;
    }

    ngOnDestroy() {
        this.notificationsHub.stop();
        this.notifySubscription.unsubscribe();
    }
}
