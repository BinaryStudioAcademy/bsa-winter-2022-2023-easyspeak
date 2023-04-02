import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { UserService } from '@core/services/user.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import { Subject } from 'rxjs';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    currentUser = new Subject<IUserInfo>();

    userFullName: string;

    constructor(private authService: AuthService, private userService: UserService) {}

    ngOnInit(): void {
        if (this.authService.isAuthenticated()) {
            this.authService.setUserSection();
        }

        this.currentUser.subscribe((resp) => this.setFullName(resp));
        this.userService.getUser().subscribe(this.currentUser);
    }

    setFullName(userInfo: IUserInfo) {
        this.userFullName = `${userInfo.firstName} ${userInfo.lastName}`;
    }

    logOut() {
        this.authService.logout();
    }
}
