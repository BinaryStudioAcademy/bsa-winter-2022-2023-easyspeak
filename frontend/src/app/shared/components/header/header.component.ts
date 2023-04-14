import { Component, OnInit, ViewChild } from '@angular/core';
import { ChatHubService } from '@core/hubs/chat-hub.service';
import { AuthService } from '@core/services/auth.service';
import { ChatService } from '@core/services/chat.service';
import { IUserShort } from '@shared/models/IUserShort';

import { UserNotificationComponent } from '../user-notification/user-notification.component';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
    @ViewChild('notificationsMenu') notificationsMenu: UserNotificationComponent;

    constructor(
        public authService: AuthService,
        private chatService: ChatService,
        private chatHub: ChatHubService,
        private webrtcHub: WebrtcHubService,
    ) {}

    currentUser: IUserShort;

    numberOfMessages: number;

    async ngOnInit(): Promise<void> {
        this.authService.loadUser().subscribe();
        await this.webrtcHub.start();

        this.authService.user.subscribe((user) => {
            this.setCurrentUser(user);

            this.chatService.getUnreadMessages(user.id as number).subscribe((numberOfMessages) => {
                this.numberOfMessages = numberOfMessages;
            });

            if (this.currentUser.email) {
                this.webrtcHub.connect(this.currentUser.email);
            }
        });

        await this.chatHub.start();

        this.chatService.getChats().subscribe((people) => {
            this.chatHub.invoke(
                'AddToGroup',
                people.map((p) => p.chatId),
            );
        });

        this.setActionsForMessages();

        this.setActionsForRead();
    }

    private setActionsForRead() {
        this.chatHub.listenRead((numberOfMessages) => {
            this.numberOfMessages -= numberOfMessages;
        });
    }

    private setActionsForMessages() {
        this.chatHub.listenMessages((msg) => {
            if (msg.createdBy !== this.currentUser.id) {
                this.numberOfMessages++;
            }
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
