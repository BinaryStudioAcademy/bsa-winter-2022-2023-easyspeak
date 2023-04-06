import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ScrollToBottomDirective } from '@shared/directives/scroll-to-bottom-directive';
import { IChatPerson } from '@shared/models/IChatPerson';
import { IMessage } from '@shared/models/IMessage';
import * as moment from 'moment';
import { Observable, of } from 'rxjs';

interface IMessageGroup {
    date: Date;
    messages: IMessage[];
}
@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.sass'],
})
export class ChatPageComponent {
    @ViewChild(ScrollToBottomDirective) scroll: ScrollToBottomDirective;

    people: IChatPerson[] = [
        { name: 'Giana Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 2 },
        { name: 'Giana Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 1 },
        { name: 'Giana Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 170 },
        { name: 'Giana Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 0 },
        { name: 'Giana Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 170 },
    ];

    totalMessage = this.people.reduce((sum, person) => sum + person.numberOfUnreadMessages, 0);

    currentChatId = 1;

    currentUserId = 1;

    messages$: Observable<[]> = of([]);

    messages: IMessage[] = [
        { chatId: 1, userId: 1, text: 'Hello', createdAt: new Date(2022, 11, 17, 17, 3) },
        { chatId: 1, userId: 1, text: 'Anyone here?', createdAt: new Date(2022, 11, 17, 17, 4) },
        { chatId: 1, userId: 2, text: 'Hi', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 1, text: 'How are you?', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 2, text: 'I am fine, thanks', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 1, text: 'Awesome :)', createdAt: new Date(2023, 2, 30, 1, 3) },
    ];

    groupedMessages: { date: Date; messages: IMessage[] }[] = [];

    constructor(private router: Router) {
        this.groupedMessages = this.groupByDate(this.messages);
    }

    groupByDate(messages: IMessage[]): IMessageGroup[] {
        return messages.reduce((acc: IMessageGroup[], message: IMessage) => {
            const messageDate = new Date(message.createdAt.toDateString());
            const messageGroupIndex = acc.findIndex((group) => {
                const groupDate = new Date(group.date.toDateString());

                return moment(groupDate.getTime()).isSame(moment(messageDate.getTime()));
            });

            if (messageGroupIndex === -1) {
                acc.push({ date: messageDate, messages: [message] });
            } else {
                acc[messageGroupIndex].messages.push(message);
            }

            return acc;
        }, []);
    }

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
            this.messages = [...this.messages, {
                chatId: this.currentChatId,
                userId: this.currentUserId,
                text: message,
                createdAt: new Date(Date.now()),
            }];
            this.groupedMessages = this.groupByDate(this.messages);

            setInterval(() => {
                this.scroll.scrollToBottom();
            }, 50);
        }
    }

    startSessionCall(): void {
        this.router.navigate([`session-call/${this.currentChatId}`]);
    }
}
