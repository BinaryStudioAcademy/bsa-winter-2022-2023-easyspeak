import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { IUserInfo } from '@shared/models/IUserInfo';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    userInfo: IUserInfo;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        if (this.authService.isAuthenticated()) {
            this.authService.setUserSection();
        }

        const userSection = this.authService.getUserSection();

        if (userSection) {
            this.userInfo = userSection;
        }
    }

    getFullName = () => `${this.userInfo.firstName} ${this.userInfo.lastName}`;

    logOut() {
        this.authService.logout();
    }
}
