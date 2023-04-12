import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ChatHubService } from '@core/hubs/chat-hub.service';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';
import { HttpService } from '@core/services/http.service';
import { ScrollToBottomDirective } from '@shared/directives/scroll-to-bottom-directive';
import { ICallUserInfo } from '@shared/models/chat/ICallUserInfo';
import { IChatPerson } from '@shared/models/chat/IChatPerson';
import { IMessage } from '@shared/models/chat/IMessage';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import { IUserShort } from '@shared/models/IUserShort';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.sass'],
})
export class ChatPageComponent implements OnInit, OnDestroy {
    @ViewChild(ScrollToBottomDirective) scroll: ScrollToBottomDirective;

    people: IChatPerson[];

    groupedMessages: IMessageGroup[] = [];

    currentUser: IUserShort;

    currentPerson: IChatPerson;

    currentChatId: number;

    allMessagesSubscription: Subscription;

    constructor(
        private router: Router,
        private httpService: HttpService,
        private chatHub: ChatHubService,
        private webrtcHub: WebrtcHubService,
    ) {}

    async ngOnInit() {
        this.currentUser = JSON.parse(localStorage.getItem('user') as string);

        await this.chatHub.start();

        await this.webrtcHub.start();

        this.httpService.get<IChatPerson[]>('/chat/lastSendMessages').subscribe((people) => {
            this.people = people;
            this.chatHub.invoke(
                'AddToGroup',
                this.people.map((p) => p.chatId),
            );
        });
        this.setActionsForMessages();

        this.setActionsForChats();
    }

    private setActionsForMessages() {
        this.chatHub.listenMessages((msg) => {
            this.addMessage(msg);
            this.chatHub.invoke('GetChatsAsync', msg.chatId, this.currentUser.id);
            if (this.currentUser.id !== msg.createdBy) {
                this.chatHub.invoke('ReadMessages', this.currentChatId, this.currentUser.id);
            }
            this.scroll.scrollToBottom();
        });
    }

    setActionsForChats() {
        this.chatHub.listenChats((people) => {
            this.people = people;
        });
    }

    async ngOnDestroy(): Promise<void> {
        await this.allMessagesSubscription.unsubscribe();
    }

    addMessage(msg: IMessage): void {
        if (this.groupedMessages.length > 0) {
            this.groupedMessages[this.groupedMessages.length - 1].messages = [
                ...this.groupedMessages[this.groupedMessages.length - 1].messages,
                msg,
            ];
        } else {
            this.groupedMessages = [
                {
                    date: new Date(msg.createdAt),
                    messages: [
                        {
                            ...msg,
                            createdAt: new Date(msg.createdAt),
                        },
                    ],
                },
            ];
        }
    }

    getChat(person: IChatPerson) {
        this.httpService.get<IMessageGroup[]>(`/chat/chatMessages/${person.chatId}`).subscribe((groupedMessages) => {
            this.groupedMessages = groupedMessages.map(
                (messageGroup): IMessageGroup => ({
                    date: new Date(messageGroup.date),
                    messages: messageGroup.messages.map(
                        (message): IMessage => ({
                            ...message,
                            createdAt: new Date(message.createdAt),
                        }),
                    ),
                }),
            );
            this.currentChatId = person.chatId;
            this.currentPerson = person;
        });
        this.chatHub.invoke('ReadMessages', person.chatId, this.currentUser.id);
    }

    sendMessage() {
        const message = this.form.controls.message.value;

        if (message) {
            this.form.reset();
            const msg: IMessage = {
                chatId: this.currentChatId,
                createdBy: this.currentUser.id,
                text: message,
                createdAt: new Date(Date.now()),
            };

            this.chatHub.invoke('SendMessageAsync', msg);
        }
    }

    getTotalUnreadMessages(): number {
        return this.people.reduce((sum, person) => sum + person.numberOfUnreadMessages, 0);
    }

    lotsOfMessages(value: number): string {
        return value < 100 ? `${value}` : '99+';
    }

    form = new FormGroup({
        message: new FormControl('', { nonNullable: true }),
        file: new FormControl(''),
    });

    startSessionCall(): void {
        const fullName = `${this.currentUser.firstName} ${this.currentUser.lastName}`;
        const callInfo: ICallUserInfo = {
            chatId: this.currentChatId,
            calleeEmail: this.currentPerson.email,
            callerId: <number> this.currentUser.id,
            callerEmail: this.currentUser.email,
            callerFullName: fullName,
            callerImgPath: this.currentUser.imagePath,
        };

        this.webrtcHub.callUser(callInfo);
    }
}
