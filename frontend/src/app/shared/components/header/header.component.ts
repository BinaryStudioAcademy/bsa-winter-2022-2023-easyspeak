import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { UserShort } from '@shared/models/UserShort';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    currentUser: UserShort = {
        email: '',
        firstName: '',
        lastName: '',
        imagePath: '',
    };

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => {
            this.currentUser = user;
        });
    }

    logOut() {
        this.authService.logout();
    }
}
