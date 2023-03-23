import { Component } from '@angular/core';
import { AuthService } from '@core/services/auth.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent {
<<<<<<< HEAD
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;
=======
    constructor(private authService: AuthService) {}

    logOut() {
        this.authService.logout();
    }
>>>>>>> development
}
