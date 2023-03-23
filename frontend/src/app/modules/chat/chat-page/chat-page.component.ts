import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
// import { HttpService } from '@core/services/http.service';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.sass'],
})
export class ChatPageComponent {
    //This values are temporary, they will be received from the server
    currentChatId = 1;

    currentUserId = 1;

    messages$: Observable<[]> = of([]);

    messages = [
        { chatId: 1, userId: 1, text: 'Hello', createdAt: new Date() },
        { chatId: 1, userId: 1, text: 'Anyone here?', createdAt: new Date() },
        { chatId: 1, userId: 2, text: 'Hi', createdAt: new Date() },
        { chatId: 1, userId: 1, text: 'How are you?', createdAt: new Date() },
        { chatId: 1, userId: 2, text: 'I am fine, thanks', createdAt: new Date() },
        { chatId: 1, userId: 1, text: 'Awesome :)', createdAt: new Date() },
    ];

    form = new FormGroup({
        message: new FormControl('', { nonNullable: true }),
    });

    constructor(private router: Router) {
    }

    sendMessage() {
        const message = this.form.controls.message.value;

        this.form.reset();

        this.messages.push({
            chatId: this.currentChatId,
            userId: this.currentUserId,
            text: message,
            createdAt: new Date(),
        });
        //this.httpService.post('messages',
        // { chatId: this.currentChatId, userId: this.currentUserId, text: message, createdAt: new Date() });
    }

    startSessionCall(): void {
        this.router.navigate([`session-call/${this.currentChatId}`]);
    }
}
