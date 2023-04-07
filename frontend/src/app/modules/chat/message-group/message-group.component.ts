import { Component, Input } from '@angular/core';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import { IUserShort } from '@shared/models/IUserShort';
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

    @Input() currentUser: IUserShort;

    today = new Date();

    showDate: boolean;

    getDateText(date: Date): string {
        if (moment(date).isSame(moment().startOf('day'))) {
            return 'Today';
        }
        if (moment(date).isSame(moment().add(-1, 'days').startOf('day'))) {
            return 'Yesterday';
        }

        return date.toLocaleDateString('en-US', { day: 'numeric', month: 'short' });
    }
}
