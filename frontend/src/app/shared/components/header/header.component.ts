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

    constructor(public authService: AuthService) {}

    currentUser: UserShort;

    ngOnInit(): void {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => this.setCurrentUser(user));
    }

    private setCurrentUser(user: UserShort) {
        this.currentUser = {
            email: user.email,
            firstName: user.firstName,
            lastName: user.lastName,
            imagePath: user.imagePath,
        };
    }

    logOut() {
        this.authService.logout();
    }
}
