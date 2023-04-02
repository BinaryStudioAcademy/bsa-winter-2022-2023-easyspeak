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

    currentUser: IUserInfo | null;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        this.authService.setUserSection().then(() => {
            this.currentUser = this.authService.getUserSection();
        });
    }

    logOut() {
        this.authService.logout();
    }
}
