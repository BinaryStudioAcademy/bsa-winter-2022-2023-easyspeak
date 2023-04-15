import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from '@core/base/base.component';
import { NotificationsHubService } from '@core/hubs/notifications-hub.service';
import { AuthService } from '@core/services/auth.service';
import { NotificationService } from '@core/services/notification.service';
import { addTimeOffset } from '@modules/lessons/lesson/lesson.helper';
import { INotification } from '@shared/models/INotification';
import { NotificationType } from '@shared/utils/user-notifications.util';
import { first, of, Subscription } from 'rxjs';

import { getTimeDiff } from './date-time-diff.helper';

@Component({
    selector: 'app-user-notification',
    templateUrl: './user-notification.component.html',
    styleUrls: ['./user-notification.component.sass'],
})
export class UserNotificationComponent extends BaseComponent implements OnInit, AfterViewInit, OnDestroy {
    readonly notificationsHub: NotificationsHubService;

    storageHasData: boolean;

    notifications: INotification[] = [];

    notifySubscription: Subscription;

    constructor(
        notificationsHub: NotificationsHubService,
        private notificationService: NotificationService,
        private router: Router,
        private authService: AuthService,
    ) {
        super();
        this.notificationsHub = notificationsHub;
    }

    async ngOnInit() {
        await this.getNotifications();
    }

    async ngAfterViewInit() {
        this.waitForUserData().then(() => {
            this.setUpHub();
        });
    }

    async waitForUserData() {
        const source = of(this.authService.user.value);
        const result = source.pipe(first(user => user !== null));

        result.subscribe(() => {
            this.notificationsHub.start().then(() => {
                this.notificationsHub.connect(this.authService.user.value.email);
            });
        });
    }

    async getNotifications() {
        this.notifySubscription = await this.notificationService.getNotifications()
            .pipe(this.untilThis)
            .subscribe((data) => {
                this.notificationsToTimeZone(data);
            });
    }

    async setUpHub() {
        this.notificationsHub.listenMessages((msg) => {
            const broadcastMessage = JSON.parse(msg);

            const messages = {
                id: broadcastMessage.Id,
                firstName: broadcastMessage.firstName,
                lastName: broadcastMessage.lastName,
                text: broadcastMessage.Text,
                type: broadcastMessage.Type,
                isRead: broadcastMessage.IsRead,
                createdAt: broadcastMessage.CreatedAt,
                imagePath: broadcastMessage.imagePath,
                link: broadcastMessage.link,
            };

            this.notifications.push(messages);
            this.notificationsToTimeZone(this.notifications);
        });
    }

    notificationsToTimeZone(newNotifications: INotification[]) {
        this.notifications = newNotifications.map(notification => ({
            ...notification,
            createdAt: new Date(addTimeOffset(notification.createdAt.toString())),
        }));
    }

    readNotification(notification: INotification) {
        notification.isRead = true;
        this.notifications = this.notifications.filter((n) => !n.isRead);

        this.notificationService.readNotification(notification.id).subscribe();
    }

    readAllNotifications() {
        this.notifications = [];

        this.notificationService.readAllNotifications().subscribe();
    }

    override ngOnDestroy(): void {
        this.notificationsHub.stop().then();
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
