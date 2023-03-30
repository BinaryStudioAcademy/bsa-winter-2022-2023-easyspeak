import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IChatPerson } from '@shared/models/IChatPerson';
import * as moment from 'moment';
// import { HttpService } from '@core/services/http.service';
import { Observable, of } from 'rxjs';

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

    setLastDate(date: Date) {
        this.lastDate = date;
    }

    getDateText(date: Date): string {
        const today = new Date();
        const yesterday = new Date(today);

        yesterday.setDate(today.getDate() - 1);

        if (date.toDateString() === today.toDateString()) {
            return 'Today';
        }
        if (date.toDateString() === yesterday.toDateString()) {
            return 'Yesterday';
        }

        return date.toLocaleDateString('en-US', { day: 'numeric', month: 'short' });
    }

    //This values are temporary, they will be received from the server
    currentChatId = 1;

    currentUserId = 1;

    messages$: Observable<[]> = of([]);

    messages = [
        { chatId: 1, userId: 1, text: 'Hello', createdAt: new Date(2022, 11, 17, 17, 3) },
        { chatId: 1, userId: 1, text: 'Anyone here?', createdAt: new Date(2022, 11, 17, 17, 4) },
        { chatId: 1, userId: 2, text: 'Hi', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 1, text: 'How are you?', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 2, text: 'I am fine, thanks', createdAt: new Date(2023, 2, 3, 1, 3) },
        { chatId: 1, userId: 1, text: 'Awesome :)', createdAt: new Date(2023, 2, 29, 1, 3) },
    ];

    form = new FormGroup({
        message: new FormControl('', { nonNullable: true }),
        file: new FormControl(''),
    });

    constructor(private router: Router) {
    }

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
        //this.httpService.post('messages',
        // { chatId: this.currentChatId, userId: this.currentUserId, text: message, createdAt: new Date() });
        }
    }

    startSessionCall(): void {
        this.router.navigate([`session-call/${this.currentChatId}`]);
    }
}
