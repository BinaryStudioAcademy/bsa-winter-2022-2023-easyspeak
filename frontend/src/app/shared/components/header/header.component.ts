import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { ILocalStorageUser } from '@shared/models/ILocalStorageUser';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    currentUser: ILocalStorageUser;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        this.authService.setUserSection().subscribe({
            next: (user) => {
                this.currentUser = user;
            },
        });
    }

    logOut() {
        this.authService.logout();
    }
}
