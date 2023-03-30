import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IChatPerson } from '@shared/models/IChatPerson';
import { IMessage } from '@shared/models/IMessage';
// import { HttpService } from '@core/services/http.service';
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
    people: IChatPerson[] = [
        { name: 'Giana Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 2 },
        { name: 'Giana Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 1 },
        { name: 'Giana Levin', isOnline: false, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 170 },
        { name: 'Giana Levin', isOnline: true, lastMessage: 'Lorem ipsum dolor sit amet consectetur?', numberOfUnreadMessages: 0 },
    ];

    today = new Date();

    totalMessage = this.people.reduce((sum, person) => sum + person.numberOfUnreadMessages, 0);

    lastDate: Date;

    //This values are temporary, they will be received from the server
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
        const result: IMessageGroup[] = [];

        messages.forEach((message) => {
            const messageDate = new Date(message.createdAt.toDateString());
            const messageGroupIndex = result.findIndex((group) => {
                const groupDate = new Date(group.date.toDateString());

                return groupDate.getTime() === messageDate.getTime();
            });

            if (messageGroupIndex === -1) {
                result.push({ date: messageDate, messages: [message] });
            } else {
                result[messageGroupIndex].messages.push(message);
            }
        });

        return result;
    }

    form = new FormGroup({
        message: new FormControl('', { nonNullable: true }),
        file: new FormControl(''),
    });

    changeChat(person: IChatPerson) {

    }

    sendMessage() {
        const message = this.form.controls.message.value;

        if (message) {
            this.form.reset();
            this.messages.push({
                chatId: this.currentChatId,
                userId: this.currentUserId,
                text: message,
                createdAt: new Date(Date.now()),
            });
            this.groupedMessages = this.groupByDate(this.messages);
        //this.httpService.post('messages',
        // { chatId: this.currentChatId, userId: this.currentUserId, text: message-group, createdAt: new Date() });
        }
    }

    startSessionCall(): void {
        this.router.navigate([`session-call/${this.currentChatId}`]);
    }
}
