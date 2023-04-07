import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ChatHubService } from '@core/hubs/chat-hub.service';
import { AuthService } from '@core/services/auth.service';
import { HttpService } from '@core/services/http.service';
import { ScrollToBottomDirective } from '@shared/directives/scroll-to-bottom-directive';
import { IChatPerson } from '@shared/models/chat/IChatPerson';
import { IMessage } from '@shared/models/chat/IMessage';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import { IUserShort } from '@shared/models/IUserShort';
import * as moment from 'moment';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.sass'],
})
export class ChatPageComponent implements OnInit, OnDestroy {
    @ViewChild(ScrollToBottomDirective) scroll: ScrollToBottomDirective;

    people: IChatPerson[];

    newMessage: IMessage;

    groupedMessages: IMessageGroup[] = [];

    currentUser: IUserShort;
    // people: IChatPerson[] = [
    // eslint-disable-next-line max-len
    //     { firstName: 'Giana', lastName: 'Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 2 },
    // eslint-disable-next-line max-len
    //     { firstName: 'Giana', lastName: 'Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 1 },
    // eslint-disable-next-line max-len
    //     { firstName: 'Giana', lastName: 'Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 170 },
    // eslint-disable-next-line max-len
    //     { firstName: 'Giana', lastName: 'Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consecrate?', numberOfUnreadMessages: 0 },
    // eslint-disable-next-line max-len
    //     { firstName: 'Giana', lastName: 'Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 170 },
    // ];
    // currentPerson: IChatPerson = {
    //     firstName: 'adsasd',
    //     lastName: 'asdasd',
    //     isOnline: true,
    //     lastMessage: 'asfasf',
    //     numberOfUnreadMessages: 0,
    //     chatId: 22,
    // };
    // messages: IMessage[] = [
    //     { chatId: 1, userId: 1, text: 'Hello', createdAt: new Date(2022, 11, 17, 17, 3) },
    //     { chatId: 1, userId: 1, text: 'Anyone here?', createdAt: new Date(2022, 11, 17, 17, 4) },
    //     { chatId: 1, userId: 2, text: 'Hi', createdAt: new Date(2023, 2, 3, 1, 3) },
    //     { chatId: 1, userId: 1, text: 'How are you?', createdAt: new Date(2023, 2, 3, 1, 3) },
    //     { chatId: 1, userId: 2, text: 'I am fine, thanks', createdAt: new Date(2023, 2, 3, 1, 3) },
    //     { chatId: 1, userId: 1, text: 'Awesome :)', createdAt: new Date(2023, 2, 30, 1, 3) },
    // ];

    currentPerson: IChatPerson;

    totalMessage: number;

    currentChatId: number;

    allMessagesSubscription: any;

    constructor(
        private router: Router,
        private httpService: HttpService,
        private chatHub: ChatHubService,
        private authService: AuthService,
    ) {

    }

    async ngOnInit() {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => {
            this.currentUser = user;
        });

        await this.chatHub.start();

        this.httpService.get<IChatPerson[]>('/chat/lastSendMessages').subscribe((people) => {
            this.people = people;
            this.totalMessage = this.people.reduce((sum, person) => sum + person.numberOfUnreadMessages, 0);
            //this.groupedMessages = this.groupByDate(this.messages);
        });

        this.chatHub.listenToSendMessages();
        this.allMessagesSubscription = this.chatHub.messages
            .subscribe((res: IMessage) => {
                this.newMessage = res;
            });
    }

    ngOnDestroy(): void {
        (<Subscription> this.allMessagesSubscription).unsubscribe();
    }

    getChat(person: IChatPerson) {
        this.httpService.get<IMessageGroup[]>(`/chat/chatMessages/${person.chatId}`).subscribe((groupedMessages) => {
            this.groupedMessages = groupedMessages.map((messageGroup): IMessageGroup => {
                return {
                    date: new Date(messageGroup.date),
                    messages: messageGroup.messages.map((message): IMessage => {
                        return {
                            ...message,
                            createdAt: new Date(message.createdAt),
                        };
                    }),
                };
            });
            this.currentChatId = person.chatId;
            this.currentPerson = person;
        });
    }

    // groupByDate(messages: IMessage[]): IMessageGroup[] {
    //     return messages.reduce((acc: IMessageGroup[], message: IMessage) => {
    //         const messageDate = new Date(message.createdAt.toDateString());
    //         const messageGroupIndex = acc.findIndex((group) => {
    //             const groupDate = new Date(group.date.toDateString());
    //
    //             return moment(groupDate.getTime()).isSame(moment(messageDate.getTime()));
    //         });
    //
    //         if (messageGroupIndex === -1) {
    //             acc.push({ date: messageDate, messages: [message] });
    //         } else {
    //             acc[messageGroupIndex].messages.push(message);
    //         }
    //
    //         return acc;
    //     }, []);
    // }

    lotsOfMessages(value: number): string {
        return value < 100 ? `${value}` : '99+';
    }

    form = new FormGroup({
        message: new FormControl('', { nonNullable: true }),
        file: new FormControl(''),
    });

    sendMessage() {
        const message = this.form.controls.message.value;

        if (message) {
            this.form.reset();
            const msg: IMessage = {
                chatId: this.currentChatId,
                userId: this.currentUser.id,
                message,
                createdAt: new Date(Date.now()),
            };

            this.chatHub.invoke(
                'SendMessageAsync',
                {
                    ...msg,
                    Text: msg.message,
                    CreatedBy: msg.userId,
                },
            );

            // setInterval(() => {
            //     this.scroll.scrollToBottom();
            // }, 50);
        }
    }

    startSessionCall(): void {
        this.router.navigate([`session-call/${this.currentChatId}`]);
    }
}
