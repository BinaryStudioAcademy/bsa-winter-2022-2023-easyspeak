import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { ChatService } from '@core/services/chat.service';
import { IUserShort } from '@shared/models/IUserShort';

import { UserNotificationComponent } from '../user-notification/user-notification.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    constructor(public authService: AuthService, private chatService: ChatService) {}

    currentUser: IUserShort;

    numberOfMessages: number;

    ngOnInit(): void {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => {
            this.setCurrentUser(user);
            this.chatService.getUnreadMessages(this.currentUser.id as number).subscribe((numberOfMessages) => {
                this.numberOfMessages = numberOfMessages;
            });
            console.log(user);
        });
    }

    private setCurrentUser(user: IUserShort) {
        this.currentUser = {
            id: user.id,
            email: user.email,
            firstName: user.firstName,
            lastName: user.lastName,
            imagePath: user.imagePath,
            isAdmin: user.isAdmin,
        };
    }

    logOut() {
        this.authService.logout();
    }
}
