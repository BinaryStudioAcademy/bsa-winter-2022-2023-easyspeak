import { Component, ViewChild } from '@angular/core';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;
}
