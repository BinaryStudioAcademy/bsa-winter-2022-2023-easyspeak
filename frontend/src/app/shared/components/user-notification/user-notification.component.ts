import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseComponent } from '@core/base/base.component';
import { NotificationsHubService } from '@core/hubs/notifications-hub.service';
import { NotificationService } from '@core/services/notification.service';
import { INotification } from '@shared/models/INotification';
import { NotificationType } from '@shared/utils/user-notifications.util';
import { Subscription } from 'rxjs';

import { getTimeDiff } from './date-time-diff.helper';

@Component({
    selector: 'app-user-notification',
    templateUrl: './user-notification.component.html',
    styleUrls: ['./user-notification.component.sass'],
})
export class UserNotificationComponent extends BaseComponent implements OnInit, OnDestroy {
    readonly notificationsHub: NotificationsHubService;

    notifications: INotification[] = [];

    notifySubscription: Subscription;

    constructor(
        notificationsHub: NotificationsHubService,
        private notificationService: NotificationService,
    ) {
        super();
        this.notificationsHub = notificationsHub;
    }

    async ngOnInit() {
        await this.getNotifications();

        await this.setUpHub();
    }

    async getNotifications() {
        this.notifySubscription = await this.notificationService.getNotifications().subscribe((data) => {
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

        this.notificationService.readNotification(notification.id).subscribe();
    }

    readAllNotifications() {
        this.notifications.map(notification => ({
            ...notification,
            isRead: true,
        }));

        this.notificationService.readAllNotifications();
    }

    override ngOnDestroy() {
        this.notificationsHub.stop();
        this.notifySubscription.unsubscribe();
    }

    getNotificationTypeIcon(type: NotificationType) {
        switch (type) {
            case NotificationType.friendshipAcception:
            case NotificationType.friendshipRequest:
                return '/assets/notifications/user-plus.svg';
            case NotificationType.reminding:
                return '/assets/notifications/link.svg';
            case NotificationType.classJoin:
                return '/assets/notifications/cofee.svg';
            default:
                return '';
        }
    }

    timeDiff(createdAt: Date): string {
        return getTimeDiff(createdAt);
    }
}
