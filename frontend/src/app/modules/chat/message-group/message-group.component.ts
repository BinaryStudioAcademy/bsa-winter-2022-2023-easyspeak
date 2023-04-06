import { Component, Input } from '@angular/core';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import * as moment from 'moment';

@Component({
    selector: 'app-message-group',
    templateUrl: './message-group.component.html',
    styleUrls: ['./message-group.component.sass'],
})
export class MessageGroupComponent {
    constructor() {
        this.showDate = true;
    }

    @Input() message: IMessageGroup;

    @Input() i: number;

    @Input() messages: IMessageGroup[];

    today = new Date();

    currentUserId = 1;

    showDate: boolean;

    getDateText(date: Date): string {
        if (moment(date).isSame(moment().startOf('day'))) {
            return 'Today';
        }
        if (moment(date).isSame(moment().add('days', -1).startOf('day'))) {
            return 'Yesterday';
        }

        return date.toLocaleDateString('en-US', { day: 'numeric', month: 'short' });
    }
}
