import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { UserService } from '@core/services/user.service';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    constructor(private authService: AuthService, private userService: UserService) {}

    ngOnInit(): void {
        if (!this.authService.isAuthenticated()) {
            this.userService.getUser(0).subscribe((resp) => {
                localStorage.setItem('user', JSON.stringify(resp));
            });
        }
    }

    logOut() {
        this.authService.logout();
    }
}
