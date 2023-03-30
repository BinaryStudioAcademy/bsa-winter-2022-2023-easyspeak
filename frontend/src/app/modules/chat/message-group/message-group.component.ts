import { Component, Input } from '@angular/core';
import { IMessage } from '@shared/models/IMessage';

@Component({
    selector: 'app-message-group',
    templateUrl: './message-group.component.html',
    styleUrls: ['./message-group.component.sass'],
})
export class MessageGroupComponent {
    constructor() {
        this.showDate = true;
    }

    @Input() message: { date: Date, messages: IMessage[] };

    @Input() i: number;

    @Input() messages: { date: Date, messages: IMessage[] }[];

    today = new Date();

    currentUserId = 1;

    showDate: boolean;

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
}
