import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        if (this.authService.isAuthenticated()) {
            this.authService.setUserSection();
        }
    }

    logOut() {
        this.authService.logout();
    }
}
