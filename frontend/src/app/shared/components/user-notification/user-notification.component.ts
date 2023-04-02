import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseComponent } from '@core/base/base.component';
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
export class UserNotificationComponent extends BaseComponent implements OnInit, OnDestroy {
    readonly notificationsHub: NotificationsHubService;

    readonly httpService: HttpService;

    notifications: INotification[] = [];

    notifySubscription: Subscription;

    constructor(
        notificationsHub: NotificationsHubService,
        httpService: HttpService,
    ) {
        super();
        this.notificationsHub = notificationsHub;
        this.httpService = httpService;
    }

    async ngOnInit() {
        await this.getNotifications();

        await this.setUpHub();
    }

    async getNotifications() {
        this.notifySubscription = await this.httpService.get<INotification[]>('/notification').subscribe((data) => {
            this.notifications = data;
        });
    }

    async setUpHub() {
        await this.notificationsHub.start();

        this.notificationsHub.listenMessages((msg) => {
            const broadcastMessage = JSON.parse(msg);

            const messages = {
                id: broadcastMessage.Id,
                text: broadcastMessage.Text,
                type: broadcastMessage.Type,
                isRead: broadcastMessage.IsRead,
                createdAt: broadcastMessage.CreatedAt,
                imagePath: broadcastMessage.imagePath,
            };

            this.notifications.push(messages);
        });
    }

    readNotification(notification: INotification) {
        notification.isRead = true;
        this.notifications = this.notifications.filter((n) => !n.isRead);

        this.httpService.put('/notification', notification.id).subscribe();
    }

    readAllNotifications() {
        this.notifications.map(notification => ({
            ...notification,
            isRead: true,
        }));

        this.httpService.put('/notification/readAll', null)
            .pipe(this.untilThis)
            .subscribe();
    }

    override ngOnDestroy() {
        this.notificationsHub.stop();
        this.notifySubscription.unsubscribe();
    }

    getNotificationTypeIcon(type: string) {
        switch (type) {
            case 'Accepted friendship request':
            case 'New friendship request':
                return '/assets/notifications/user-plus.svg';
            case 'Lesson reminding':
                return '/assets/notifications/link.svg';
            case 'Group class join':
                return '/assets/notifications/cofee.svg';
            default:
                return '';
        }
    }

    getTimeDiff(createdAt: Date): string {
        const date = moment(createdAt);

        const diffInMinutes = moment().diff(date, 'minutes');

        if (diffInMinutes < 1) {
            return 'Just now';
        }
        if (diffInMinutes < 60) {
            return `${diffInMinutes} minutes ago`;
        }
        if (diffInMinutes < 1440) {
            const diffInHours = moment().diff(date, 'hours');

            return `${diffInHours} hours ago`;
        }
        if (diffInMinutes < 10080) {
            const diffInDays = moment().diff(date, 'days');

            return `${diffInDays} days ago`;
        } if (diffInMinutes < 43200) {
            const diffInWeeks = moment().diff(date, 'weeks');

            return `${diffInWeeks} weeks ago`;
        }

        const diffInMonths = moment().diff(date, 'months');

        return `${diffInMonths} months ago`;
    }
}
